using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace AzureAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context != null)
                {
                    context.Database.Migrate();

                    if (!context.ProductType.Any())
                    {
                        context.ProductType.AddRange(new List<ProductType>()
                        {
                            new ProductType()
                            {
                                Name = "Comic"
                            },
                            new ProductType()
                            {
                                Name = "Fiction"
                            },
                            new ProductType()
                            {
                                Name = "Romantic"
                            },
                            new ProductType()
                            {
                                Name = "Programming"
                            }
                        });
                        context.SaveChanges();
                    }
                    if (!context.ProductBrand.Any())
                    {
                        context.ProductBrand.AddRange(new List<ProductBrand>()
                        {
                            new ProductBrand()
                            {
                                Name = "Tramp Press"
                            },
                            new ProductBrand()
                            {
                                Name = "Mighty Media"
                            },
                            new ProductBrand()
                            {
                                Name = "Harvest House Publishers"
                            },
                            new ProductBrand()
                            {
                                Name = "Springer Nature"
                            },
                            new ProductBrand()
                            {
                                Name = "Graywolf Press"
                            },
                            new ProductBrand()
                            {
                                Name = "Forever"
                            }
                        });
                        context.SaveChanges();
                    }
                    if (!context.Product.Any())
                    {
                        context.Product.AddRange(new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Superma: Action Comics Volume 5: The House of Kentn",
                                Description = "The House of Kent, Superman, Superboy, Supergirl, the Legion of Super-Heroes’ Brainiac 5, and Young Justice’s Conner Kent must all unite to face an enemy from another dimension unleashed by the Invisible Mafia! This kind of power can lay waste to an entire family of super-people! All of this plus the future of the Daily Planet revealed!",
                                Price = 12.99m,
                                PictureUrl = "images/products/BOOK-COMIC-1000.jpg",
                                ProductTypeId = 1,
                                ProductBrandId = 1
                            },
                            new Product()
                            {
                                Name = "Batman: The Silver Age Omnibus Vol. 1 ",
                                Description = "The Caped Crusader is known for protecting the streets of Gotham from the villains who wish to cause harm. Follow along on some of his most adventurous tales in Batman: The Silver Age Omnibus Vol. 1 collecting Batman #101-116",
                                Price = 99.99m,
                                PictureUrl = "images/products/BOOK-COMIC-1001.jpg",
                                ProductTypeId = 1,
                                ProductBrandId = 1
                            },
                            new Product()
                            {
                                Name = "The Fifth Science",
                                Description = "The Fifth Science is a collection of 12 stories, beginning at the start of the Galactic Human Empire and following right through to its final days. We’ll see some untypical things along the way, meet some untypical folk: galactic lighthouses from the distant future, alien tombs from the distant past, murderers, emperors, archaeologists and drunks; mad mathematicians attempting to wake the universe itself up.And when humans have fallen back into savagery, when the secrets of space folding and perfect wisdom are forgotten, we’ll attend the empire’s deathbed, hold its hand as it goes. Unfortunately that may well only be the beginning.",
                                Price = 24.99m,
                                PictureUrl = "images/products/BOOK-FICTION-1002.jpg",
                                ProductTypeId = 2,
                                ProductBrandId = 2
                            },
                            new Product()
                            {
                                Name = "The Summer House: A gorgeous feel good romance that will have you hooked",
                                Description = "Just when true happiness seems within reach, Callie and Olivia find a diary full of secrets... secrets that stretch across the island, and have the power to turn lives upside down. As Callie reads, she unravels a mystery that makes her heart drop through the floor. Will Callie and Luke be pulled apart by the storm it unleashes, or can true love save them?",
                                Price = 15.00m,
                                PictureUrl = "images/products/BOOK-ROMANTIC-1003.jpg",
                                ProductTypeId = 3,
                                ProductBrandId = 2
                            },
                            new Product()
                            {
                                Name = "The Art of Computer Programming",
                                Description = "These four books comprise what easily could be the most important set of information on any serious programmer’s bookshelf.",
                                Price = 187.99m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1004.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 4
                            },
                            new Product()
                            {
                                Name = "Python Programming for Beginners : The Ultimate Guide for Beginners to Learn Python Programming: Crash Course on Python Programming for Beginners",
                                Description = "Python is a high-level interpreted programming language that is used throughout the world for general-purpose programming. It is an open-source programming language licensed by both the Free Software Foundation (FSF) and Open-Source Initiative (OSI). Like some other programming languages, its source code is also available under the GNU General Public License (GPL). Throughout this book, we will be focusing more on the Python 3.x version, which is the latest and is currently in active development.",
                                Price = 21.99m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1005.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 5
                            },
                            new Product()
                            {
                                Name = "The Self-Taught Programmer: The Definitive Guide to Programming Professionally",
                                Description = "This book is not just about learning to program; although you will learn to code. If you want to program professionally, it is not enough to learn to code; that is why, in addition to helping you learn to program, I also cover the rest of the things you need to know to program professionally that classes and books don't teach you. The Self-taugh  t Programmer is a roadmap, a guide to take you from writing your first Python program, to passing your first technical interview.",
                                Price = 21.87m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1006.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 2
                            },
                            new Product()
                            {
                                Name = "Computer Programming: The Bible: Learn from the basics to advanced of Python, C, C++, C#, HTML Coding, and Black Hat Hacking Step-by-Step in No Time!",
                                Description = "Are you ready to learn and start programming with any language in less than 12 hours? The world of technology is changing and those who know how to handle it and who have the most knowledge about it are the ones who will get ahead. If you are a beginner who is interested in learning more and getting ahead, then this guidebook is the one for you.",
                                Price = 14.95m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1007.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 4
                            },
                            new Product()
                            {
                                Name = "Effective C: An Introduction to Professional C Programming",
                                Description = "Effective C will teach you how to write professional, secure, and portable C code that will stand the test of time and help strengthen the foundation of the computing world.",
                                Price = 35.01m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1008.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 6
                            },
                            new Product()
                            {
                                Name = "Head First Design Patterns: Building Extensible and Maintainable Object-Oriented Software 2nd Edition",
                                Description = "If you've read a Head First book, you know what to expect: a visually rich format designed for the way your brain works. With Head First Design Patterns, 2E you'll learn design principles and patterns in a way that won't put you to sleep, so you can get out there to solve software design problems and speak the language of patterns with others on your team.",
                                Price = 32.43m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1009.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 3
                            },
                            new Product()
                            {
                                Name = "Beginning Programming All-in-One Desk Reference For Dummies",
                                Description = "Beginning Programming All In One Desk Reference For Dummies shows you how to decide what you want your program to do, turn your instructions into “machine language” that the computer understands, use programming best practices, explore the “how” and “why” of data structuring, and more. You’ll even get a look into various applications like database management, bioinformatics, computer security, and artificial intelligence. Soon you’ll realize that — wow! You’re a programmer!",
                                Price = 32.89m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1010.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 3
                            },
                            new Product()
                            {
                                Name = "Machine Learning: 4 Books in 1: A Complete Overview for Beginners to Master the Basics of Python Programming and Understand How to Build Artificial Intelligence Through Data Science",
                                Description = "Created with the beginner in mind, this powerful bundle delves into the fundamentals behind Python and machine learning, from basic code and mathematical formulas to complex neural networks and ensemble modeling. Inside, you’ll discover everything you need to know to get started with Python and machine learning and begin your journey to success!",
                                Price = 35.01m,
                                PictureUrl = "images/products/BOOK-PROGRAMMING-1011.jpg",
                                ProductTypeId = 4,
                                ProductBrandId = 4
                            }
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
