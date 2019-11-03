using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        struct Time
        {
            #region Свойства
            public int Week { get; set; }
            public int Day { get; set; }
            public int Hour { get; set; }
            public int Minute { get; set; }

            enum Days
            {
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday,
                Sunday
            }
            #endregion

            #region Конструкторы структуры
            public Time(int week, int day, int hour, int minute)
            {
                this.Week = week;
                this.Day = day;
                this.Hour = hour;
                this.Minute = minute;
            }
            #endregion

            #region Методы работы со структурой
            /// <summary>
            /// Переопределение оператора +
            /// </summary>
            /// <param name="Time1"></param>
            /// <param name="Time2"></param>
            /// <returns>Итоговое время после сложения</returns>
            public static Time operator+ (Time Time1, Time Time2)
            {
                var newTime = new Time();
                newTime.Minute = Time1.Minute + Time2.Minute;
                newTime.Hour = Time1.Hour + Time2.Hour;
                newTime.Day = Time1.Day + Time2.Day;
                newTime.Week = Time1.Week + Time2.Week;
                if (newTime.Minute >= 60)
                {
                    newTime.Hour++;
                    newTime.Minute = newTime.Minute - 60;
                }
                if (newTime.Hour >= 24)
                {
                    newTime.Day++;
                    newTime.Hour = newTime.Hour - 24;
                }
                if (newTime.Day >= 7)
                {
                    newTime.Week++;
                    newTime.Day = newTime.Day - 7;
                }
                return newTime;
            }
            
            /// <summary>
            /// Переопределение оператора -
            /// </summary>
            /// <param name="Time1"></param>
            /// <param name="Time2"></param>
            /// <returns>Итоговое время после вычитания</returns>
            public static Time operator- (Time Time1, Time Time2)
            {
                var newTime = new Time();
                newTime.Minute = Time1.Minute - Time2.Minute;
                newTime.Hour = Time1.Hour - Time2.Hour;
                newTime.Day = Time1.Day - Time2.Day;
                newTime.Week = Time1.Week - Time2.Week;
                if (newTime.Minute < 0)
                {
                    newTime.Hour--;
                    newTime.Minute = 60 + newTime.Minute;
                }
                if (newTime.Hour < 0)
                {
                    newTime.Day--;
                    newTime.Hour = 24 + newTime.Hour;
                }
                if (newTime.Day < 0)
                {
                    newTime.Week--;
                    newTime.Day = 7 + newTime.Day;
                }
                newTime.Week = Math.Abs(newTime.Week);
                return newTime;
            }

            /// <summary>
            /// Делаем нормальный вывод через консоль
            /// </summary>
            /// <returns>Строка вывода структуры</returns>
            public override string ToString()
            {
                if (Minute < 10)
                {
                    return $"Week: {Week}, Day: {(Days)Day}, Time: {Hour}:0{Minute}";
                }
                else 
                {
                    return $"Week: {Week}, Day: {(Days)Day}, Time: {Hour}:{Minute}";
                }
            }
            #endregion
        }


        static void Main(string[] args)
        {
            var Time1 = new Time(3, 5, 10, 30);
            var Time2 = new Time(4, 5, 23, 30);
            Console.WriteLine(Time1 + Time2);
            Console.WriteLine(Time1-Time2);
            Console.ReadKey();
        }
    }
}