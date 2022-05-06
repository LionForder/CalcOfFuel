using System;

namespace CalcDis
{ 
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Для начала введите 'старт'. Для выхода введите 'стоп':");
            string line = Console.ReadLine();
            if(line.ToLower() == "старт")
                while(line.ToLower() == "старт")
                {
                    Console.WriteLine("Пожалуйста, введите количество километров, которые необходимо проехать(цел. числ.):");
                    int km = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите расход топлива(дробное(10,5; 13,0)):");
                    double topl = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Если один или несколько из условий соответствуют вашему пути, введите эти числа через пробел подряд(будет прибавлено максимально возможное значение для уверенности в запасах бензина). Если таковых нет, просто нажмите 'Enter':");
                    Console.WriteLine("1. Работа в зимний период.");
                    Console.WriteLine("2. Эксплуатация в горной местности.");
                    Console.WriteLine("3. Дороги сложного плана, опасные участки дорог.");
                    Console.WriteLine("4. Передвижение в городских зонах.");
                    Console.WriteLine("5. Необходимость частых технологических остановок.");
                    Console.WriteLine("6. Необходимость низкой скорости движения.");
                    Console.WriteLine("7. Для обкатки нового авто.");
                    string str = Console.ReadLine();
                    if(str!=null)
                        {
                            string[] polz = str.Split();
                            var bens = new CalcBens() {Km=km, Raskhod=topl, Property=polz};
                            bens.Calculate();
                        }
                    else 
                    {
                        var bens = new CalcBens() {Km=km, Raskhod=topl};
                        bens.CalculateNormal();
                    }
                    Console.WriteLine("Для продолжения введите 'старт'. Для выхода введите 'стоп':");
                    line = Console.ReadLine();

                }
        }
    }
    class CalcBens
    {
        private int km = 1;
        private double raskhod = 5.0;
        private string[] property;

        public string[] Property
        { 
            get {return property;}
            set {property = value;} }
        public int Km 
        {
            get{return km;}
            set{if(value > 0) km = value;}
        }
        public double Raskhod 
        { 
            get {return raskhod;}
            set {if(value > 0) raskhod = value;} 
        }

        public void CalculateNormal()
        {
            Console.WriteLine($"При расходе {Raskhod} л/100км и расстоянии {Km} без условных преград, желаемое количество бензина: {Convert.ToInt32(Raskhod * Km / 100) + 1}л");
        }

        public void Calculate()
        {
            int raskh = Convert.ToInt32(Raskhod * Km / 100) + 1;
            foreach(var el in property)
            {
                switch(el)
                {
                    case "1":
                        raskh += Convert.ToInt32(Raskhod * 2 / 10) + 1;
                        break;
                    case "2":
                        raskh += Convert.ToInt32(Raskhod * 2 / 10) + 1;
                        break;
					case "3":
                        raskh += Convert.ToInt32(Raskhod * 15 / 100) + 1;
                        break;
                    case "4":
                        raskh += Convert.ToInt32(Raskhod * 35 / 100) + 1;
                        break;
                    case "5":
                        raskh += Convert.ToInt32(Raskhod / 10) + 1;
                        break;
                    case "6":
                        raskh += Convert.ToInt32(Raskhod * 35 / 100) + 1;
                        break;
                    case "7":
                        raskh += Convert.ToInt32(Raskhod / 10) + 1;
                        break;
                }
            }
                        Console.WriteLine($"При расходе {Raskhod} л/100км и расстоянии {Km} без условных преград, желаемое количество бензина: {raskh}л");
        }

    }
}