using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Zombow.Core.CommandPattern.Contracts;
using Zombow.Models.Bows.Contracts;

namespace ViceCity.Core.CommandPattern.Commands
{
    public class AddBowCommand : ICommand
    {
        private List<string> args;

        public AddBowCommand(IList<string> args)
        {
            this.args = args.ToList();
        }

        public string Execute()
        {
            string type = args[0];
            string name = args[1];

            IBow bow = bowFactory.CreateBow(type, name);  

            if (bow != null)
            { 
                this.bows.Enqueue(bow);
                return $"Successfully added {name} of type: {type}";
            }

            return "Invalid bow type!";
        }
    }
}
