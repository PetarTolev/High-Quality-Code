namespace ViceCity.Models.Bows
{
    using Zombow.Models.Bows;

    public class TakedownBow : Bow
    {
        public TakedownBow(string name)
            : base(name)
        { 
            this.QuiverCapacity = 50;
            this.TotalArrows = 500;
        }

        public override int Shoot()
        {
            if (this.QuiverCapacity == 0)
            {
                this.Reload();

                if (this.QuiverCapacity == 0)
                {
                    return 0;
                }
            }
            this.QuiverCapacity -= 5;

            return 5;
        }

        protected override void Reload()
        {
            if (this.TotalArrows > 0)
            {
                this.QuiverCapacity += 50;
                this.TotalArrows -= 50;
            }
        }
    }
}
