# Вопрос 1
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным

*Решение задачи в коде*

# Вопрос 2
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
По возможности — положите ответ рядом с кодом из первого вопроса.

## Создание таблицы товаров:
```sql
CREATE TABLE "Products" (
    "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);
```

## Создание таблицы категорий:
```sql
CREATE TABLE "Categories" (
    "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);
```

## Создание развязочной таблицы:
```sql
CREATE TABLE "ProductToCategories" (
    "ProductId" INTEGER NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    FOREIGN KEY("ProductId") REFERENCES "Products"("Id"),
    FOREIGN KEY("CategoryId") REFERENCES "Categories"("Id"),
    PRIMARY KEY("ProductId", "CategoryId")
);
```

## Заполняем таблицы данными
```sql
INSERT INTO "Products" ("Name") VALUES ('Смартфон');
INSERT INTO "Products" ("Name") VALUES ('Ноутбук');
INSERT INTO "Products" ("Name") VALUES ('Планшет');
INSERT INTO "Products" ("Name") VALUES ('Телевизор');
INSERT INTO "Products" ("Name") VALUES ('Наушники');
INSERT INTO "Products" ("Name") VALUES ('Камера');

INSERT INTO "Categories" ("Name") VALUES ('Электроника');
INSERT INTO "Categories" ("Name") VALUES ('Мобильные устройства');
INSERT INTO "Categories" ("Name") VALUES ('Аудио и видео');

INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (1, 1);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (1, 2);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (2, 1);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (2, 2);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (3, 2);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (4, 3);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (5, 3);
INSERT INTO "ProductToCategories" ("ProductId", "CategoryId") VALUES (6, 1);
```

## Решение задачи:
```sql
SELECT Products.Name AS ProductName, Categories.Name AS CategoryName
FROM Products
LEFT JOIN ProductToCategories ON Products.Id = ProductToCategories.ProductId
LEFT JOIN Categories ON ProductToCategories.CategoryId = Categories.Id;
```
