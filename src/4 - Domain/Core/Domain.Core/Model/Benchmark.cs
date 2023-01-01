using Domain.Commons.Entity;
using Domain.Core.Enumerables;
using System;

namespace Domain.Core.Model
{
    public class Benchmark : EntityBase
    {
        public EnumBenchmark Name { get; init; }

        public double Value { get; init; }

        public DateTime Data { get; init; }

        public Benchmark(int id, EnumBenchmark name, double value, DateTime data) : base(id)
        {
            Name = name;
            Value = value;
            Data = data;
        }

        public Benchmark(EnumBenchmark name, double value, DateTime data)
        {
            Name = name;
            Value = value;
            Data = data;
        }       
    }
}