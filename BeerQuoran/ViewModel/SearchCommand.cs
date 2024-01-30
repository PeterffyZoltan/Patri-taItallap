using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeerQuoran.ViewModel
{
    public class SearchCommand : ICommand
    {
        public Values? VALS { get; set; }

        public SearchCommand(Values vals)
        {
            VALS = vals;
        }

        event EventHandler? ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            string? query = parameter as string;
            if (string.IsNullOrWhiteSpace(query)) return false;
            return true;
        }

        void ICommand.Execute(object? parameter)
        {
            VALS.MakeQuery();
        }
    }
}
