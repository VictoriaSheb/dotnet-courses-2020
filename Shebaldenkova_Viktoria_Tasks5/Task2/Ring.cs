using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Ring : Round
    {
        private double RadiusExternal { get; }
        private double RadiusInternal { get; }
        public override double Area 
        {
            get 
            {
                Radius = RadiusExternal;
                double AreaRadiusExternal = base.Area;
                Radius = RadiusInternal;
                double AreaRadiusInternal = base.Area;
                return AreaRadiusExternal - AreaRadiusInternal;
            }
        }
        public override  double Length
        {
            get
            {
                Radius = RadiusExternal;
                double LengthRadiusExternal = base.Length;
                Radius = RadiusInternal;
                double LengthRadiusInternal = base.Length;
                return LengthRadiusExternal + LengthRadiusInternal;
            }
        }


        public Ring(double x, double y, double radiusExternal, double radiusInternal) : base(x, y) 
        {
            CheckRing(radiusExternal, radiusInternal);
            RadiusInternal= CheckRadius(radiusInternal);
            RadiusExternal = CheckRadius(radiusExternal);
        }

        protected void CheckRing(double radiusExternal, double radiusInternal) 
        {
            if (radiusExternal < radiusInternal)
                throw new Exception("Внутренний радиус не должен быть меньше внешнего"); 
        }


    }
}
