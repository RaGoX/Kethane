﻿
namespace Kethane
{
    internal interface IResourceGenerator
    {
        IBodyResources Load(CelestialBody body, ConfigNode node);
    }

    internal interface IBodyResources
    {
        ConfigNode Save();
        ICellResource GetResource(GeodesicGrid.Cell cell);
        double MaxQuantity { get; }
    }

    internal interface ICellResource
    {
        double Quantity { get; set; }
    }

    internal class EmptyResourceGenerator : IResourceGenerator
    {
        private readonly IBodyResources bodyResources = new BodyResources();

        public EmptyResourceGenerator() { }
        public EmptyResourceGenerator(ConfigNode node) { }

        public IBodyResources Load(CelestialBody body, ConfigNode node) { return bodyResources; }

        private class BodyResources : IBodyResources
        {
            public double MaxQuantity { get { return 0; } }
            public ConfigNode Save() { return new ConfigNode(); }
            public ICellResource GetResource(GeodesicGrid.Cell cell) { return null; }
        }
    }
}