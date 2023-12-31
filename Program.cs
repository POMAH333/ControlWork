﻿/*
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

    switch (menuNum)
    {
        case 0: return;
        case 1: TaskStr(); break;
        case 2: TaskStr(true); break;
        default: Console.WriteLine($"Задачи №{menuNum}, не существует"); break;
    }
}

//-----------------------------------------------------------------------------------

void TaskStr(bool autoArray = false)
{
    int num = SetNumber("Введите количество элементов массива:");
    int strLen = 3;
    string arrNullQuot = "\""; //Переменная для добавления кавычек при выводе массива

    string[] arrayStart = new string[num];

    if (autoArray)
    {
        arrayStart = AutoArrayComplet(num);
    }
    else
    {
        arrayStart = ManualArrayComplet(num);
    }

    if (arrayStart.Length == 0) arrNullQuot = ""; //Если массив нулевой, убрать кавычки
    Console.WriteLine($"Начальный массив: [{arrNullQuot}{string.Join("\", \"", arrayStart)}{arrNullQuot}]");
    Console.WriteLine();

    string[] arrayResult = StrMinLenArray(arrayStart, strLen);

    if (arrayResult.Length == 0) //Если массив нулевой, убрать кавычки, если нет, то установить
    {
        arrNullQuot = "";
    }
    else
    {
        arrNullQuot = "\"";
    }
    Console.WriteLine($"Итоговый массив: [{arrNullQuot}{string.Join("\", \"", arrayResult)}{arrNullQuot}]");
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("Нажмите любую клавишу для продолжения");
    Console.ReadKey();
}



int SetNumber(string messageEnt)
{
    Console.WriteLine(messageEnt);
    int num = int.Parse(Console.ReadLine());
    return num;
}



string[] ManualArrayComplet(int size)
{
    string[] array = new string[size];

    for (int i = 0; i < size; i++)
    {
        Console.WriteLine($"Введите значение элемента № {i}: ");
        array[i] = Console.ReadLine();
    }

    return array;
}


string[] AutoArrayComplet(int size)
{
    string[] array = new string[size];

    Random random = new Random();
    int rndMax = 0;
    array[0] = StrArray(0, out rndMax);

    for (int i = 0; i < size; i++)
    {
        array[i] = StrArray(random.Next(0, rndMax), out rndMax);
    }

    return array;
}



string[] StrMinLenArray(string[] array, int strMaxLen)
{
    int resultLen = 0;
    int[] arrayTemp = new int[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= strMaxLen)
        {
            arrayTemp[resultLen] = i;
            resultLen++;
        }
    }

    string[] result = new string[resultLen];

    for (int i = 0; i < resultLen; i++)
    {
        result[i] = array[arrayTemp[i]];
    }

    return result;

}



string StrArray(int index, out int rndMax)
{
    string[] strArray = {"Привет", "как дела", "что нового", "все хорошо", "отлично", "прекрасно", "замечательно",
    "нормально", "неплохо", "потихоньку", "пока", "всего хорошего", "до свидания", "счастливо", "до встречи",
    "спокойной ночи", "доброго утра", "удачного дня", "приятного аппетита", "спасибо", "пожалуйста", "извини",
    "прости", "будь здоров", "крепкого здоровья", "береги себя", " днем рождения", " праздником", "это тебе",
    "рад помочь", "всегда пожалуйста", "нет проблем", "без проблем", "конечно", "договорились", "будет сделано",
    "сделаю все возможное", "приходи в гости", "ждем в гости", "заходите", "обращайтесь", "вот мой номер телефона",
    "звони", "пиши", "адрес электронной почты", "номер телефона", "сайт", "ссылка", "имейл", "текст", "сообщение",
    "письмо", "комментарий", "лайк", "репост", "поделиться", "фото", "картинка", "видео", "голосование", "опрос", "мнение",
    "отзыв", "абв", "abc", "yu", "123", "qwerty", "йцукенгшщзхъ", "фывапролджэ", "ячсмитьбю", "poiuytrewq", "asdfghjkl",
    "zxcvbnm", "йц", "цу", "ке", "нл", "жэ", "эж", "ыц", "вм", "фв", "ff", "ад", "ва", "дол", "ав", "вс", "св", "вд",
    "да", "авб", "авс", "абц", "абд", "абва", "абве", "абвг", "абде", "абжэ", "абзх", "абч", "абш", "абщ", "абъ",
    "абэ", "абю", "абю", "абь", "абй", "абцй", "абцу", "абк", "ак", "акц", "акш", "акщ", "акъ", "акэ", "акю", "акь",
    "акй", "акцу", "акк", "ал", "алц", "алч", "алш", "алщ", "алъ", "алэ", "алю", "аль", "алй", "алцу", "алле", "ам",
    "амц", "амч", "амш", "амщ", "амъ", "амэ", "амю", "амь", "амй", "амцу", "амк", "ан", "анц", "анч", "анш", "анщ",
    "анъ", "анэ", "аню", "ань", "анй", "анцу", "ане", "ап", "апц", "апч", "апш", "апщ", "апъ", "апэ", "апю", "апь",
    "апй", "апцу", "апк", "lk", "арц", "арч", "арш", "арщ", "аръ", "длорп"};

    rndMax = strArray.Length;
    return strArray[index];
}
