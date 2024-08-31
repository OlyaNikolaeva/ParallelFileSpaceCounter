# ParallelFileSpaceCounter
An application designed for parallel reading of text files from a user-selected folder and counting the number of spaces in their contents. The program uses the power of multiple tasks using the Task class to speed up file processing.

## Результаты измерения времени выполнения

| Количество файлов | Общее количество пробелов | Время выполнения (мс) |
|-------------------|---------------------------|-----------------------|
| 3                 | 144                       | 22                    |
| 3                 | 743                       | 37                    |
| 3                 | 688                       | 33                    |
| 3                 | 3970                      | 119                   |