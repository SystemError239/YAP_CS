public class QuadraticEquation
{
    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    public QuadraticEquation(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double[] GetRoots()
    {
        double d = B * B - 4 * A * C;

        if (A == 0)
        {
            if (B != 0)
            {
                return new double[] { -C / B };
            }
            else
            {
                return new double[0];
            }
        }

        if (d < 0)
        {
            return new double[0];
        }
        else if (d == 0)
        {
            return new double[] { -B / (2 * A) };
        }
        else
        {
            double sqrtD = Math.Sqrt(d);
            return new double[]
            {
                (-B + sqrtD) / (2 * A),
                (-B - sqrtD) / (2 * A)
            };
        }
    }

    public override string ToString()
    {
        return $"{A}x^2 + {B}x + {C} = 0";
    }

    public static QuadraticEquation operator ++(QuadraticEquation q)
    {
        return new QuadraticEquation(q.A + 1, q.B + 1, q.C + 1);
    }

    public static QuadraticEquation operator --(QuadraticEquation q)
    {
        return new QuadraticEquation(q.A - 1, q.B - 1, q.C - 1);
    }

    public static implicit operator double(QuadraticEquation q)
    {
        return q.B * q.B - 4 * q.A * q.C;
    }

    public static explicit operator bool(QuadraticEquation q)
    {
        return q.GetRoots().Length > 0;
    }

    public static bool operator ==(QuadraticEquation q1, QuadraticEquation q2)
    {
        if (ReferenceEquals(q1, q2)) return true;
        if (ReferenceEquals(q1, null) || ReferenceEquals(q2, null)) return false;
        return q1.A == q2.A && q1.B == q2.B && q1.C == q2.C;
    }

    public static bool operator !=(QuadraticEquation q1, QuadraticEquation q2)
    {
        return !(q1 == q2);
    }

    public override bool Equals(object obj)
    {
        if (obj is QuadraticEquation q)
        {
            return this == q;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();
    }
}
