using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{

    public class Student
    {
        public int Id;
        public string Name;
        public int Age;
    }

    public class StudentScore
    {
        public int StudentId;
        public float English;
        public float Maths;
    }

    class Program 
    {
        static void Main(string[] args)
        {
            Student[] student = new Student[]{
                new Student{Id=1,Name="ZhangSan",Age=20},
                new Student{Id=2,Name="LiSi",Age=22},
                new Student{Id=3,Name="WangWu",Age=19}
            };
            StudentScore[] score = new StudentScore[] {
                new StudentScore{StudentId = 1, English = 90, Maths = 90},
                new StudentScore{StudentId = 2, English = 95, Maths = 85},
                new StudentScore{StudentId = 3, English = 80, Maths = 100}
            };

            var list = student.Join(
                score, 
                o=>o.Id,
                i=>i.StudentId,
                (o,i)=>new{Name = o.Name,English = i.English, Maths = i.Maths}
            );

            foreach(var e in list){
                Console.WriteLine(e);
            }

            Console.WriteLine("==================================================");

            var list2 = from o in student
                        from i in score 
                        where o.Id == i.StudentId 
                        orderby i.Maths 
                        select new {Name = o.Name, English = i.English, Maths = i.Maths};
            foreach(var e in list2){
                Console.WriteLine(e);
            }
        }
    }
}