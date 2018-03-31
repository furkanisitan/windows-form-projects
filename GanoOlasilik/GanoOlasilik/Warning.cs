using System;
using System.Collections.Generic;

namespace GanoOlasilik
{
    public static class Warning
    {
        public enum Warnings
        {
            LessonNameorCredit_NullorEmpty,
            LessonNameIsNotUnique,
            LessonCreditIsNotPositiveInt,
            LessonNotEnter,
            EmptyPointorCredit,
            WrongPointorCredit,
        };

        public static Dictionary<Enum, string> warnings = new Dictionary<Enum, string>
        {
            {Warnings.LessonNameorCredit_NullorEmpty,"Ders adı ve kredi boş geçilemez."},
            {Warnings.LessonNameIsNotUnique,"Aynı isimde bir ders adı zaten mevcut."},
            {Warnings.LessonCreditIsNotPositiveInt,"Ders kredisi pozitif bir tamsayı olmalıdır."},
            {Warnings.LessonNotEnter,"Ders giriniz."},
            {Warnings.EmptyPointorCredit,"Puan ve kredi değerlerini giriniz."},
            {Warnings.WrongPointorCredit,"Toplam puan veya kredi hatalı girilmiş."}
        };
    }
}
