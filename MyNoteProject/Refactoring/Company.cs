namespace Refactoring
{
    internal class Company
    {
        public string CompanyNM { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        public int Fee { get; set; }
       
        public Company(string CompanyNM, int Weight, int Size)
        {
            this.CompanyNM = CompanyNM;
            this.Weight = Weight;
            this.Size = Size;
        }

        public int Calculate()
        {
            return this.Weight * this.Size;
        }
    }
}