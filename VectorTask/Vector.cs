using System;
using System.Linq;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] _components;

        public int Size => _components.Length;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Length = {size}. It must be greater than 0!", nameof(size));
            }

            _components = new double[size];
        }

        public Vector(Vector vector)
        {
            _components = new double[vector._components.Length];
            vector._components.CopyTo(_components, 0);
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException($"Size = {components.Length}. It must be greater than 0!", nameof(components.Length));
            }

            _components = new double[components.Length];

            components.CopyTo(_components, 0);
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size = {size}. It must be greater than 0!", nameof(size));
            }

            _components = new double[size];

            var min = Math.Min(components.Length, size);

            Array.Copy(components, _components, min);
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _components.Length)
                {
                    throw new ArgumentOutOfRangeException($"Index = {index}. It must be greater than or equal to 0 and less {_components.Length}", nameof(index));
                }

                return _components[index];
            }
            set
            {
                if (index < 0 || index >= _components.Length)
                {
                    throw new ArgumentOutOfRangeException($"Index = {index}. It must be greater than or equal to 0 and less {_components.Length}", nameof(index));
                }

                _components[index] = value;
            }
        }

        public void Add(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (var i = 0; i < vector._components.Length; i++)
            {
                _components[i] += vector[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (_components.Length < vector._components.Length)
            {
                Array.Resize(ref _components, vector._components.Length);
            }

            for (var i = 0; i < vector._components.Length; i++)
            {
                _components[i] -= vector[i];
            }
        }

        public void MultiplyByScalar(double number)
        {
            for (var i = 0; i < _components.Length; i++)
            {
                _components[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            var sum = _components.Sum(e => e * e);

            return Math.Sqrt(sum);
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.Add(vector2);

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1);

            result.Subtract(vector2);

            return result;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            var minLength = Math.Min(vector1._components.Length, vector2._components.Length);

            double scalarProduct = 0;

            for (var i = 0; i < minLength; i++)
            {
                scalarProduct += vector1[i] * vector2[i];
            }

            return scalarProduct;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("{");
            sb.Append(_components[0]);

            for (var i = 1; i < _components.Length; i++)
            {
                sb.Append(", ");
                sb.Append(_components[i]);
            }

            sb.Append("}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var vector = (Vector)obj;

            if (vector._components.Length != _components.Length)
            {
                return false;
            }

            return !_components.Where((t, i) => t != vector._components[i]).Any();
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return _components.Aggregate(1, (current, element) => prime * current + element.GetHashCode());
        }
    }
}