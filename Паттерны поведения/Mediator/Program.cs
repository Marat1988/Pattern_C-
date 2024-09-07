namespace Mediator
{
    interface IMediator
    {
        void Notify(Employee emp, string msg);
    }

    abstract class Employee
    {
        protected IMediator mediator;
        public Employee(IMediator mediator) => this.mediator = mediator;
        public void SetMediator(IMediator med)=> this.mediator = med;
    }

    class Designer: Employee
    {
        private bool isWorking;
        public Designer(IMediator med = null): base(med) { }

        public void ExecuteWork()
        {
            Console.WriteLine("<-Дизайнер в работе");
            mediator.Notify(this, "Дизайнер проектирует....");
        }
        public void SetWork(bool state)
        {
            isWorking = state;
            if (state)
            {
                Console.WriteLine("<-Дизайнер освобожден от работы");
            }
            else
            {
                Console.WriteLine("<=Дизайнер занят");
            }
        }
    }

    class Director: Employee
    {
        private string text;
        public Director(IMediator mediator = null): base(mediator) { }

        public void GiveCommand(string txt)
        {
            text = txt;
            if (text == "")
                Console.WriteLine("->Директор знает, что дизайнер уже работает");
            else
                Console.WriteLine("->Директор дал команду: " + text);
            mediator.Notify(this, text);
        }
    }

    class Controler: IMediator
    {
        private Designer designer;
        private Director director;
        public Controler(Designer designer, Director director)
        {
            this.designer = designer;
            this.director = director;
            designer.SetMediator(this);
            director.SetMediator(this);
        }
        public void Notify(Employee emp, string msg)
        {
            if (emp is Director dir)
            {
                if (msg == "")
                    designer.SetWork(false);
                else
                    designer.SetWork(true);
            }
            if (emp is Designer des)
            {
                if (msg == "Дизайнер проектирует....")
                    director.GiveCommand("");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Designer designer = new Designer();
            Director director = new Director();
            Controler mediator = new Controler(designer, director);

            director.GiveCommand("Проектировать");
            Console.WriteLine();

            designer.ExecuteWork();



        }
    }
}
