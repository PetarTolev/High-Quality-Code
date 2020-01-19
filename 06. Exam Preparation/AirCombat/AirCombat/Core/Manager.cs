namespace AirCombat.Core
{
    using Contracts;
    using Entities.AirCrafts.Contracts;
    using Entities.AirCrafts.Factories;
    using Entities.AirCrafts.Factories.Contracts;
    using Entities.Parts.Contracts;
    using Entities.Parts.Factories;
    using Entities.Parts.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utils;

    public class Manager : IManager
    {
        private readonly IDictionary<string, IAirCraft> aircrafts;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> defeatedAircrafts;
        private readonly IBattleOperator battleOperator;

        private readonly IAirCraftFactory aircraftFactory;
        private readonly IPartFactory partFactory;

        public Manager(IBattleOperator battleOperator)
        {
            this.battleOperator = battleOperator;

            this.partFactory = new PartFactory();
            this.aircraftFactory = new AirCraftFactory();

            this.aircrafts = new Dictionary<string, IAirCraft>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedAircrafts = new List<string>();
        }

        public string AddAircraft(IList<string> arguments)
        {
            string aircraftType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IAirCraft aircraft =
                this.aircraftFactory.CreateAirCraft(aircraftType, model, weight, price, attack, defense, hitPoints);

            if (aircraft == null)
            {
                throw new ArgumentNullException("This AirCraft type does not exist!");
            }

            this.aircrafts.Add(aircraft.Model, aircraft);

            return string.Format(
                GlobalConstants.AircraftSuccessMessage,
                aircraftType,
                aircraft.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string aircraftModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = this.partFactory.CreatePart(partType, model, weight, price, additionalParameter);
            
            this.parts[partType] = part;

            switch (partType)
            {
                case "Arsenal":
                    this.aircrafts[aircraftModel].AddArsenalPart(part);
                    break;
                case "Shell":
                    this.aircrafts[aircraftModel].AddShellPart(part);
                    break;
                case "Endurance":
                    this.aircrafts[aircraftModel].AddEndurancePart(part);
                    break;
            }

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                aircraftModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];

            string result = this.aircrafts.ContainsKey(model) ?
                this.aircrafts[model].ToString() :
                this.parts[model].ToString();

            return result;
        }

        public string Battle(IList<string> arguments)
        {
            string attackerAircraftModel = arguments[0];
            string targetAircraftModel = arguments[1];

            string winnerAircraftModel = this.battleOperator.Battle(this.aircrafts[attackerAircraftModel], this.aircrafts[targetAircraftModel]);

            if (winnerAircraftModel.Equals(attackerAircraftModel))
            {
                this.aircrafts[targetAircraftModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.aircrafts.Remove(targetAircraftModel);
                this.defeatedAircrafts.Add(targetAircraftModel);
            }
            else
            {
                this.aircrafts[attackerAircraftModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.aircrafts.Remove(attackerAircraftModel);

                this.defeatedAircrafts.Add(attackerAircraftModel);
            }

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerAircraftModel,
                targetAircraftModel,
                winnerAircraftModel);
        }

        public string Terminate()
        {
            StringBuilder finalResult = new StringBuilder();

            finalResult.Append("Remaining Aircrafts: ");

            if (this.aircrafts.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ",
                        this.aircrafts
                            .Values
                            .Select(v => v.Model)
                            .ToArray()));
            }
            else
            {
                finalResult.AppendLine("None");
            }

            finalResult.Append("Defeated Aircrafts: ");

            if (this.defeatedAircrafts.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.defeatedAircrafts));
            }
            else
            {
                finalResult
                    .AppendLine("None");
            }

            finalResult
                .Append("Currently Used Parts: ")
                .Append(this.parts.Count);

            return finalResult.ToString();
        }
    }
}