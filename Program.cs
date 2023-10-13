/*
Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам.
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:

[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]

[“1234”, “1567”, “-2”, “computer science”] → [“-2”]

[“Russia”, “Denmark”, “Kazan”] → []
*/

//-----------------------------------------------------------------------------------

while (true)
{
    Console.Clear();
    Console.WriteLine("Выберите способ заполнения массива:");
    Console.WriteLine("1) Ручное заполнение, посредством ввода строк с клавиатуры");
    Console.WriteLine("2) Автоматическое заполнение из заданного массива строк");
    Console.WriteLine();
    Console.WriteLine("0) Или введите 0 для выхода из программы");
    int menuNum = SetNumber("");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    switch (menuNum)
    {
        case 0: return;
        case 1: TaskStr(); break;
        case 2: TaskStr(true); break;
        default: Console.WriteLine($"Задачи №{menuNum}, не существует"); break;
    }
}

//-----------------------------------------------------------------------------------

int SetNumber(string messageEnt)
{
    Console.WriteLine(messageEnt);
    int num = int.Parse(Console.ReadLine());
    return num;
}



void TaskStr(bool autoArray = false)
{
    int num = SetNumber("Введите количество элементов массива:");

    if (autoArray)
    {
        int[] array = AutoArrayComplet(num);
    }
    else
    {
        int[] array = ManualArrayComplet(num);
    }

    Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]");
    Console.WriteLine("Нажмите любую клавишу для продолжения");
    Console.ReadKey();
}


