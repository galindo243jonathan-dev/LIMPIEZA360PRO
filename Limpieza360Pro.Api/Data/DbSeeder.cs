using Limpieza360Pro.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limpieza360Pro.Api.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            // Propiedad principal
            if (!context.Properties.Any())
            {
                                // Asignar valores por defecto a Status y PhotoUrl en todas las tareas
                var generalTasks = new List<TaskItem>
                {
                    new TaskItem { Type = "Limpieza General", Description = "Barrer y trapear toda la casa.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza General", Description = "Quitar el polvo de todas las superficies y decoración usando un trapo húmedo.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza General", Description = "Limpiar los televisores cuidadosamente sin dejar marcas en la pantalla.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza General", Description = "Revisar zócalos y esquinas para asegurarse de que estén limpios.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza General", Description = "Limpiar telaraña.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Sala", Description = "Limpiar todas las superficies.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Sala", Description = "Mover los cojines del sofá y verificar que no haya suciedad ni hormigas debajo.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Sala", Description = "Organizar cojines y dejar la sala ordenada.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Comedor", Description = "Limpiar mesa, sillas y superficies.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Comedor", Description = "Asegurarse de que el área quede limpia y ordenada.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Cocina", Description = "Limpiar superficies, gabinetes por fuera y por dentro.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Verificar que los gabinetes estén limpios y organizados y funcionales.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Limpiar la cafetera y su filtro.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Verificar que el dispensador de jabón de loza esté lleno.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Dejar toallas de cocina limpias y disponibles para los visitantes.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Limpiar microondas por dentro y por fuera.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Limpiar el filtro de agua.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Limpiar la nevera por dentro y por fuera (no dejar alimentos).", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Cocina", Description = "Lavar las canecas de basura y colocar bolsas nuevas.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Baños", Description = "Limpiar ducha (pisos y paredes).", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Limpiar divisiones de vidrio y asegurarse de que no queden marcas.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Limpiar espejo, sanitario y lavamanos con Clorox.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Lavar las canecas de basura y colocar bolsas nuevas.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Verificar disponibilidad de toallas: Máximo 10 toallas blancas de cuerpo en toda la casa. Máximo 4 toallas de mano en total (1 por baño).", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Dejar un rollo de papel higiénico nuevo instalado en cada baño.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Dejar un rollo extra en el cuarto de lavado.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Baños", Description = "Lavar y volver a colocar los tapetes de baño.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Habitaciones", Description = "Revisar que no haya objetos dentro de los cajones.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Habitaciones", Description = "Lavar sábanas y hacer las camas correctamente.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Habitaciones", Description = "Limpiar el polvo de todas las superficies.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Habitaciones", Description = "Lavar los tapetes de la habitación y volver a colocarlos limpios.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Zona de Lavado", Description = "Limpiar el filtro de la lavadora en cada lavada.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Zona de Lavado", Description = "Limpiar el gabinete debajo del lavadero.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Zona de Lavado", Description = "Dejar ganchos de ropa disponibles.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Zona de Lavado", Description = "Dejar toallas disponibles para la piscina.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Área de BBQ", Description = "Barrer y trapear el área.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de BBQ", Description = "Limpiar mesa y superficies.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de BBQ", Description = "Limpiar la mini nevera y no dejar ningún alimento dentro.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de BBQ", Description = "Limpiar la parrilla con el cepillo (no usar agua).", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de BBQ", Description = "Retirar las cenizas del carbón.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de BBQ", Description = "Dejar toda el área limpia y ordenada.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Área de Piscina", Description = "Barrer y trapear el área.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Área de Piscina", Description = "Organizar los muebles alrededor de la piscina.", IncompleteReason = "", EmployeeId = null },

                    new TaskItem { Type = "Terraza", Description = "Limpiar el piso de la terraza.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Terraza", Description = "Limpiar superficies.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Terraza", Description = "Organizar los cojines de la sala exterior.", IncompleteReason = "", EmployeeId = null },
                };

                // Tareas de limpieza profunda
                var deepTasks = new List<TaskItem>
                {
                    new TaskItem { Type = "Limpieza Profunda", Description = "Lavar los forros de los muebles (sofás, sillas y cojines).", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza Profunda", Description = "Limpiar todas las ventanas y ventanales de la casa, por dentro y por fuera.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza Profunda", Description = "Limpiar con hidrolavadora el piso exterior, incluyendo escaleras, terraza y placas vehiculares.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza Profunda", Description = "Lavar la caneca grande de basura ubicada debajo de la escalera.", IncompleteReason = "", EmployeeId = null },
                    new TaskItem { Type = "Limpieza Profunda", Description = "Limpiar las paredes y los guardaescobas de toda la casa.", IncompleteReason = "", EmployeeId = null },
                };

                var allTasks = generalTasks.Concat(deepTasks).ToList();
                // Asignar valores por defecto a Status y PhotoUrl en todas las tareas
                foreach (var task in allTasks)
                {
                    if (string.IsNullOrEmpty(task.Status))
                        task.Status = "Pendiente";
                    if (string.IsNullOrEmpty(task.PhotoUrl))
                        task.PhotoUrl = "";
                }
                var property = new Property
                {
                    Name = "EPIC D1",
                    Address = "",
                    Description = "Casa EPIC D1",
                    Tasks = allTasks
                };
                context.Properties.Add(property);
                await context.SaveChangesAsync();

                // Crear usuarios iniciales para EPIC D1
                var users = new List<(string UserName, string FullName, string Role, string Password)>
                {
                    ("jonathan.galindo", "Jonathan Galindo", "Owner", "galindo123"),
                    ("carlina.yepes", "Carlina Yepes", "Empleado Limpieza", "yepes123"),
                    ("victor.peralta", "Victor Peralta", "Empleado Mantenimiento", "peralta123"),
                    ("alejandra.vela", "Alejandra Vela", "Manager", "vela123")
                };
                foreach (var (userName, fullName, role, password) in users)
                {
                    if (await userManager.FindByNameAsync(userName) == null)
                    {
                        var user = new ApplicationUser
                        {
                            UserName = userName,
                            FullName = fullName,
                            Role = role,
                            PropertyId = property.Id,
                            Email = userName + "@mail.com"
                        };
                        await userManager.CreateAsync(user, password);
                    }
                }
            }

            // Crear propiedad y usuarios para TORRE MAGNA
            if (!context.Properties.Any(p => p.Name == "TORRE MAGNA"))
            {
                var magnaTasks = new List<TaskItem>
                {
                    // ...existing code...
                };
                // Asignar valores por defecto a Status y PhotoUrl en todas las tareas de Torre Magna
                foreach (var task in magnaTasks)
                {
                    if (string.IsNullOrEmpty(task.Status))
                        task.Status = "Pendiente";
                    if (string.IsNullOrEmpty(task.PhotoUrl))
                        task.PhotoUrl = "";
                }
                var property = new Property
                {
                    Name = "TORRE MAGNA",
                    Address = "",
                    Description = "Propiedad TORRE MAGNA",
                    Tasks = magnaTasks
                };
                context.Properties.Add(property);
                await context.SaveChangesAsync();

                var users = new List<(string UserName, string FullName, string Role, string Password)>
                {
                    ("alejandro.sabedra", "Alejandro Sabedra", "Empleado Limpieza y Mantenimiento", "alejandro123"),
                    ("jose.grisales", "Jose Grisales", "Manager", "grisales123")
                };
                foreach (var (userName, fullName, role, password) in users)
                {
                    if (await userManager.FindByNameAsync(userName) == null)
                    {
                        var user = new ApplicationUser
                        {
                            UserName = userName,
                            FullName = fullName,
                            Role = role,
                            PropertyId = property.Id,
                            Email = userName + "@mail.com"
                        };
                        await userManager.CreateAsync(user, password);
                    }
                }
            }
        }
    }
}