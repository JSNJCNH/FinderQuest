using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    public class QuestionBankBoss
    {
        public class BossQuestion
        {
            public string Question { get; set; }
            public string ReferenceAnswer { get; set; } // jawaban ideal, buat pembanding Claude

            public BossQuestion(string question, string referenceAnswer)
            {
                Question = question;
                ReferenceAnswer = referenceAnswer;
            }
        }

        public static class QuestionBank
        {
            public static List<BossQuestion> BossQuestions = new List<BossQuestion>
            {
                new BossQuestion(
                    "Jelaskan apa yang dimaksud dengan Encapsulation (enkapsulasi) dalam OOP dan mengapa konsep ini penting.",
                    "Encapsulation adalah konsep menyembunyikan detail internal sebuah class dan hanya mengekspos apa yang perlu diakses dari luar, biasanya lewat access modifier seperti private, public, protected, serta menggunakan property/getter-setter. Tujuannya adalah melindungi data dari perubahan yang tidak diinginkan dari luar class, menjaga integritas data, dan memudahkan maintenance karena implementasi internal bisa diubah tanpa mempengaruhi kode lain yang menggunakan class tersebut."
                ),

                new BossQuestion(
                    "Jelaskan konsep Inheritance (pewarisan) dalam OOP beserta contoh penggunaannya.",
                    "Inheritance adalah mekanisme di mana sebuah class (child/subclass) dapat mewarisi properti dan method dari class lain (parent/superclass). Tujuannya untuk reuse code, menghindari duplikasi, dan membentuk hubungan is-a antar class. Contohnya class Animal sebagai parent dengan method Eat() dan Sleep(), lalu class Dog dan Cat sebagai child yang mewarisi method tersebut sekaligus bisa menambahkan atau override method sendiri seperti Bark() atau Meow()."
                ),

                new BossQuestion(
                    "Apa perbedaan antara Polymorphism secara overriding dan overloading? Jelaskan dengan contoh.",
                    "Overriding adalah ketika subclass menyediakan implementasi berbeda untuk method yang sudah didefinisikan di parent class, biasanya menggunakan keyword virtual di parent dan override di child, dan terjadi pada runtime (dynamic polymorphism). Overloading adalah ketika beberapa method memiliki nama sama tapi parameter berbeda (jumlah atau tipe data) dalam satu class, dan ditentukan saat compile time (static polymorphism). Contoh overriding: method Speak() di class Animal di-override berbeda di Dog dan Cat. Contoh overloading: method Add(int a, int b) dan Add(double a, double b) dalam class yang sama."
                ),

                new BossQuestion(
                    "Jelaskan apa itu Abstraction dalam OOP dan bagaimana cara mengimplementasikannya di C#.",
                    "Abstraction adalah konsep menyembunyikan detail implementasi yang kompleks dan hanya menampilkan fitur atau fungsi penting yang relevan bagi pengguna class. Di C# bisa diimplementasikan menggunakan abstract class atau interface. Abstract class bisa punya method abstract (tanpa implementasi, wajib di-override child) dan method biasa, sedangkan interface hanya mendefinisikan kontrak method tanpa implementasi sama sekali (sebelum C# 8). Contoh: interface IShape dengan method CalculateArea(), diimplementasikan berbeda oleh class Circle dan Rectangle sesuai rumus masing-masing."
                ),

                new BossQuestion(
                    "Apa perbedaan antara Class dan Object dalam OOP?",
                    "Class adalah blueprint atau cetakan yang mendefinisikan struktur, properti, dan behavior (method) yang akan dimiliki oleh sesuatu, sedangkan Object adalah instance konkret yang dibuat dari class tersebut menggunakan keyword new. Satu class bisa digunakan untuk membuat banyak object dengan nilai properti yang berbeda-beda. Contoh: class Mobil mendefinisikan atribut seperti Warna dan Kecepatan, sedangkan objek mobilSaya = new Mobil() adalah instance nyata dengan nilai spesifik seperti Warna = 'Merah'."
                ),

                new BossQuestion(
                    "Jelaskan apa itu constructor dalam OOP dan apa fungsinya.",
                    "Constructor adalah method khusus dalam sebuah class yang otomatis dipanggil saat object dari class tersebut dibuat menggunakan keyword new. Fungsinya untuk menginisialisasi nilai awal dari properti/field object tersebut. Constructor punya nama yang sama dengan nama class dan tidak memiliki return type. Sebuah class bisa memiliki lebih dari satu constructor dengan parameter berbeda (constructor overloading), dan jika tidak didefinisikan sama sekali, compiler akan otomatis menyediakan default constructor tanpa parameter."
                ),

                new BossQuestion(
                    "Mengapa penggunaan interface dianggap penting dalam OOP, terutama untuk desain sistem yang fleksibel?",
                    "Interface penting karena memungkinkan sebuah class mengimplementasikan banyak kontrak sekaligus (multiple inheritance of behavior), yang tidak bisa dilakukan lewat inheritance class biasa di C# karena hanya mendukung single inheritance. Interface memisahkan 'apa yang harus dilakukan' dari 'bagaimana caranya dilakukan', sehingga kode menjadi lebih loosely coupled, mudah di-testing (misal lewat mocking), dan mudah diperluas tanpa mengubah kode yang sudah ada, sesuai prinsip Open-Closed dalam SOLID."
                ),

                new BossQuestion(
                    "Jelaskan apa yang dimaksud dengan access modifier private, public, dan protected, serta kapan sebaiknya masing-masing digunakan.",
                    "Private membuat anggota class (field/method) hanya bisa diakses dari dalam class itu sendiri, cocok untuk data internal yang tidak boleh diubah langsung dari luar. Public membuat anggota class bisa diakses dari mana saja, cocok untuk method atau properti yang memang dirancang sebagai antarmuka publik class tersebut. Protected mirip private, tapi tetap bisa diakses oleh class turunan (subclass), cocok digunakan saat ingin membagikan sesuatu ke child class tapi tetap menyembunyikannya dari kode luar yang tidak berelasi."
                ),
            };
        }

    }
}