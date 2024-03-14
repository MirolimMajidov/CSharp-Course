using SOLID.SRP;
using SOLID.OCP;
using SOLID.ISP;
using SOLID.DIP;

var user = new User() { Name = "Ali", EmailAddress = "Ali@ali.com" };
var emailService = new EmailService();
emailService.SendEmail(user, $"Salom {user.Name} bro");

var animals = new List<IAnimal>();
animals.Add(new Cat());
animals.Add(new Cat());
animals.Add(new Bird());
animals.Add(new Bird());

var allFlayableAnimals = animals.OfType<ICanFly>(); 

var logger1 = new FileLogger();
var workerService1 = new WorkerService(logger1);
workerService1.DoWork();

var logger2 = new DBLogger();
var workerService2 = new WorkerService(logger2);
workerService2.DoWork();