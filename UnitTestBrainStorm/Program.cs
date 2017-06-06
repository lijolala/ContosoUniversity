using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBrainStorm
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public int Add(int i, int j)
        {
            int result;
            result = i + j;
            return result;
        }

    }

    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }

    public interface ICommand
    {
        void Execute();
        event EventHandler Executed;
    }

    public class SomethingThatNeedsACommand
    {
        ICommand command;
        public SomethingThatNeedsACommand(ICommand command)
        {
            this.command = command;
        }
        public void DoSomething()
        {
            command.Execute();
        }
        public void DontDoAnything() { }
    }

        
  
}
