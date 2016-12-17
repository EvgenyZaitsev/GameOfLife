# GameOfLife
Задание к модулю 4. Реализация игры "Жизнь"

Данная реализация написана на языке C# по правилам, представленным на Википедии:
Распределение живых клеток в начале игры называется первым поколением. Каждое следующее поколение рассчитывается на основе предыдущего по таким правилам:
1.В пустой (мёртвой) клетке, рядом с которой ровно три живые клетки, зарождается жизнь;
2. Если у живой клетки есть две или три живые соседки, то эта клетка продолжает жить; в противном случае (если соседей меньше двух или больше трёх) клетка умирает («от одиночества» или «от перенаселённости»)
Игра прекращается, если
1. На поле не останется ни одной «живой» клетки
2. Конфигурация на очередном шаге в точности (без сдвигов и поворотов) повторит себя же на одном из более ранних шагов (складывается периодическая конфигурация)
3. При очередном шаге ни одна из клеток не меняет своего состояния (складывается стабильная конфигурация; предыдущее правило, вырожденное до одного шага назад)

В данном проекте реализована возможность ручного составления начального сотояния (записывается в файл "Text.txt", лежащий в мамке с исходным кодом в формате 
%высота таблицы% %ширина таблицы%
%матрица заданной размерности%
Разделителями являются пробелы, "мертвая" клетка - 0, "живая" - всё остальное).
Так же можно включить автогенерацию, как параметры которой передаются размерности и шанс создания "живой" клетки. По умолчанию эти значения равны 10*10 и 0.5.
Управление этим происходит через консоль.
Каждая итерация выводится на консоль и дублируется в файл с именем "%Текущая дата с точностью до секунды%_result.txt".
Данный код так же представлен по ссылке https://github.com/EvgenyZaitsev/GameOfLife

Авторы: Зайцев Евгений Дмитриевич, Вахромин Алексей Олегович, Лимонтова Ольга Евгеньевна, 4 курс, 5 группа.