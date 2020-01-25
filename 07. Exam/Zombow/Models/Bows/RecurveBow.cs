namespace ViceCity.Models.Bows
{
    using Zombow.Models.Bows;

    public class RecurveBow : Bow
    {
        public RecurveBow(string name)
            : base(name)
        {
            this.QuiverCapacity = 10;
            this.TotalArrows = 100;
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
            this.QuiverCapacity--;

            return 1;
        }

        protected override void Reload()
        {
            if (this.TotalArrows > 0)
            {
                this.QuiverCapacity += 10;
                this.TotalArrows -= 10;
            }
        }
    }
}
