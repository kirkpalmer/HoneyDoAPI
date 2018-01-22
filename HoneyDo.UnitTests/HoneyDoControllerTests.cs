using HoneyDo.Data;
using HoneyDo.Data.Entity;
using HoneyDoAPI.Controllers;
using HoneyDoAPI.Model;
using HoneyDoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HoneyDo.UnitTests
{
    public class HoneyDoControllerTests
    {
        public HoneyDoControllerTests()
        {
           
        }
        [Fact(DisplayName = "GetTasks_Ok_HoneyDoTaskViewList")]
        public void GetTasks_Ok_HoneyDoTaskViewList()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

           using(var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1),
                    new HoneyDoTask("Jump Up and Down","Get that exercise",new DateTime(2018,01,25),4),
            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);

                // Act
                var result = cntrlr.GetAll();

                // Assert
                var viewResult = Assert.IsType<OkObjectResult>(result);
                var viewModel = Assert.IsType<List<HoneyDoTaskView>>(viewResult.Value);
            }
            
        }

        [Fact(DisplayName = "GetTasks_NotFound_HoneyDoTaskViewList_Null")]
        public void GetTasks_NotFound_HoneyDoTaskViewList_Null()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTestNull");
            var options = builder.Options;

            
            // Arrange
            using (var cxt = new HoneyDoContext(options)){
                var cntrlr = new HoneyDoController(cxt);

                // Act
                var result = cntrlr.GetAll();
                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
           
        }

        [Fact(DisplayName = "GetTask_Ok_HoneyDoTask")]
        public void GetTask_Ok_HoneyDoTask()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1),
                    new HoneyDoTask("Jump Up and Down","Get that exercise",new DateTime(2018,01,25),4),
            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);

                // Act
                var result = cntrlr.GetById(2);

                // Assert
                var viewResult = Assert.IsType<OkObjectResult>(result);
                var viewModel = Assert.IsType<HoneyDoTaskView>(viewResult.Value);
            }

        }
        [Fact(DisplayName = "GetTask_NotFound_HoneyDoTask_Null")]
        public void GetTask_NotFound_HoneyDoTask_Null()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2)
            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);

                // Act
                var result = cntrlr.GetById(0);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }

        }

        [Fact(DisplayName = "Create_Ok_NoContentResult")]
        public void Create_Ok_NoContentResult()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1)
                    
            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);
                //create Item
                var task = new HoneyDoTaskView(new HoneyDoTask("Jump Up and Down", "Get that exercise", new DateTime(2018, 01, 25), 4));

                // Act
                var result = cntrlr.Create(task);

                // Assert
                var viewResult = Assert.IsType<CreatedAtRouteResult>(result);
                Assert.Equal(expected: "GetSingleHoneyDoTask", actual: viewResult.RouteName);
            }
        }
        [Fact(DisplayName = "Create_BadRequest_Null")]
        public void Create_BadRequest_Null()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1)

            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);
                //create Item
                HoneyDoTaskView task = null;
            
                // Act
                var result = cntrlr.Create(task);

                // Assert
                Assert.IsType<BadRequestResult>(result);
               
            }
        }

        [Fact(DisplayName = "Update_Ok_NoContentResult")]
        public void Update_Ok_NoContentResult()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1)

            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);
                //Act
                var itm = context.HoneyDoTasks.FirstOrDefault(x => x.Id == 1);
                var result = cntrlr.Update(1, new HoneyDoTaskView(itm));

                // Assert
                var viewResult = Assert.IsType<BadRequestResult>(result);
            }
        }

        [Fact(DisplayName = "Update_BadRequest_Null")]
        public void Update_BadRequest_Null()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1)

            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);
                //Act
                var result = cntrlr.Update(1, new HoneyDoTaskView() { Id = 2, Name = "Do Not Brush Teeth", Description = "" });

                // Assert
                Assert.IsType<BadRequestResult>(result);

            }
        }

        [Fact(DisplayName = "Delete_Record_NoContentResult")]
        public void Delete_Record_NoContentResult()
        {
            var builder = new DbContextOptionsBuilder<HoneyDoContext>();
            builder.UseInMemoryDatabase("HoneyDoTest");
            var options = builder.Options;

            using (var context = new HoneyDoContext(options))
            {
                var Tasks = new List<HoneyDoTask>
            {
                    new HoneyDoTask("Brush Teeth","Appointment Coming Up",new DateTime(2018,01,20),2),
                    new HoneyDoTask("Change Oil In Car","Not sounding Good",new DateTime(2018,01,20),1)

            };

                context.AddRange(Tasks);
                context.SaveChanges();
            }
            using (var context = new HoneyDoContext(options))
            {
                var cntrlr = new HoneyDoController(context);
                //Act
                var result = cntrlr.Delete(1);

                // Assert
                var viewResult = Assert.IsType<NoContentResult>(result);
            }
        }
    }
}
