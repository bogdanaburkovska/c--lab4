using System;
using System.Collections.Generic;
using System.Linq;

class Запис
{
    public string Прізвище { get; set; }
    public string ЕлектроннаПошта { get; set; }
}

class УправлінняЗаписами
{
    private const string ШляхДоФайлу = "database.txt";

    public List<Запис> ЧитатиЗаписи()
    {
        List<Запис> записи = new List<Запис>();
        // Читання записів з текстового файлу і заповнення списку
        return записи;
    }

    public void ЗаписатиЗаписи(List<Запис> записи)
    {
        // Запис записів у текстовий файл
    }
}

class Program
{
    static void Main(string[] args)
    {
        УправлінняЗаписами управління = new УправлінняЗаписами();
        List<Запис> записи = управління.ЧитатиЗаписи();

        bool вихід = false;
        while (!вихід)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати Запис");
            Console.WriteLine("2. Редагувати Запис");
            Console.WriteLine("3. Видалити Запис");
            Console.WriteLine("4. Показати Записи");
            Console.WriteLine("5. Пошук Записів за Електронною Поштою");
            Console.WriteLine("6. Сортувати Записи за Прізвищем");
            Console.WriteLine("7. Показати Базу Даних");
            Console.WriteLine("Введіть вибір:");

            string вибір = Console.ReadLine();
            switch (вибір)
            {
                case "1":
                    ДодатиЗапис(записи);
                    break;
                case "2":
                    РедагуватиЗапис(записи);
                    break;
                case "3":
                    ВидалитиЗапис(записи);
                    break;
                case "4":
                    ПоказатиЗаписиТаблицею(записи);
                    break;
                case "5":
                    ПошукЗаписівЗаЕлектронноПоштою(записи);
                    break;
                case "6":
                    СортуватиЗаписиЗаПрізвищем(записи);
                    break;
                case "7":
                    ПоказатиБазуДаних(записи);
                    break;
                case "вихід":
                    вихід = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }

        управління.ЗаписатиЗаписи(записи);
    }

    static void ДодатиЗапис(List<Запис> записи)
    {
        Console.WriteLine("Введіть Прізвище:");
        string прізвище = Console.ReadLine();

        Console.WriteLine("Введіть Електронну Пошту:");
        string електроннаПошта = Console.ReadLine();

        записи.Add(new Запис
        {
            Прізвище = прізвище,
            ЕлектроннаПошта = електроннаПошта
        });
        Console.WriteLine("Запис Додано Успішно!");
    }

    static void РедагуватиЗапис(List<Запис> записи)
    {
        Console.WriteLine("Введіть Прізвище для Редагування:");
        string прізвище = Console.ReadLine();

        Запис запис = записи.FirstOrDefault(r => r.Прізвище == прізвище);
        if (запис == null)
        {
            Console.WriteLine("Запис Не Знайдено!");
            return;
        }

        Console.WriteLine("Введіть Нову Електронну Пошту:");
        string новаЕлектроннаПошта = Console.ReadLine();

        запис.ЕлектроннаПошта = новаЕлектроннаПошта;
        Console.WriteLine("Запис Відредаговано Успішно!");
    }

    static void ВидалитиЗапис(List<Запис> записи)
    {
        Console.WriteLine("Введіть Прізвище для Видалення:");
        string прізвище = Console.ReadLine();

        Запис запис = записи.FirstOrDefault(r => r.Прізвище == прізвище);
        if (запис == null)
        {
            Console.WriteLine("Запис Не Знайдено!");
            return;
        }

        записи.Remove(запис);
        Console.WriteLine("Запис Видалено Успішно!");
    }

    static void ПоказатиЗаписиТаблицею(List<Запис> записи)
    {
        Console.WriteLine("┌─────────────────┬────────────────────┐");
        Console.WriteLine("│     Прізвище    │  Електронна Пошта  │");
        Console.WriteLine("├─────────────────┼────────────────────┤");

        foreach (var запис in записи)
        {
            Console.WriteLine($"│ {запис.Прізвище,-15} │ {запис.ЕлектроннаПошта,-20} │");
        }

        Console.WriteLine("└─────────────────┴────────────────────┘");
    }

    static void ПоказатиЗаписИнфо(Запис запис)
    {
        Console.WriteLine("┌─────────────────┬────────────────────┐");
        Console.WriteLine("│     Прізвище    │  Електронна Пошта  │");
        Console.WriteLine("├─────────────────┼────────────────────┤");
        Console.WriteLine($"│ {запис.Прізвище,-15} │ {запис.ЕлектроннаПошта,-20} │");
        Console.WriteLine("└─────────────────┴────────────────────┘");
    }

    static void ПоказатиБазуДаних(List<Запис> записи)
    {
        Console.WriteLine("Вміст Бази Даних:");
        ПоказатиЗаписиТаблицею(записи);
    }

    static void ПоказатиЗаписи(List<Запис> записи)
    {
        foreach (var запис in записи)
        {
            Console.WriteLine($"Прізвище: {запис.Прізвище}");
            Console.WriteLine($"Електронна Пошта: {запис.ЕлектроннаПошта}");
            Console.WriteLine();
        }
    }

    static void ПошукЗаписівЗаЕлектронноПоштою(List<Запис> записи)
    {
        Console.WriteLine("Введіть Електронну Пошту для Пошуку:");
        string пошуковаЕлектроннаПошта = Console.ReadLine();

        var результатиПошуку = записи.Where(r => r.ЕлектроннаПошта == пошуковаЕлектроннаПошта);

        if (результатиПошуку.Any())
        {
            Console.WriteLine("Результати Пошуку:");
            foreach (var результат in результатиПошуку)
            {
                ПоказатиЗаписИнфо(результат);
            }
        }
        else
        {
            Console.WriteLine("Записів з такою Електронною Поштою не знайдено.");
        }
    }

    static void СортуватиЗаписиЗаПрізвищем(List<Запис> записи)
    {
        записи = записи.OrderBy(r => r.Прізвище).ToList();
        Console.WriteLine("Записи Відсортовано за Прізвищем Успішно!");
        ПоказатиЗаписиТаблицею(записи);
    }
}
