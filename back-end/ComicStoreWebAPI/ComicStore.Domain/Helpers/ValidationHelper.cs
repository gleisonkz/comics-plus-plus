using ComicStore.Shared.Class;
using System;

namespace ComicStore.Domain.Helpers
{
    public static class ValidationHelper
    {
        public static Validators<T> SetValidation<T>(T valueToAssign) where T : struct
        {
            return new Validators<T>(valueToAssign);
        }
    }

    public class Validators<T> where T : struct
    {
        private readonly T _valueToAssign;
        private readonly dynamic zeroValue = 0;

        public Validators(T valueToAssign)
        {
            _valueToAssign = valueToAssign;
        }

        public Validators<T> LessThanZero()
        {
            if (_valueToAssign < zeroValue)
                throw new LessThanZeroException("A quantidade não pode ser menor que 0");
            return this;
        }

        public Validators<T> EqualsZero()
        {
            if (_valueToAssign == zeroValue)
                throw new EqualZeroException();
            return this;
        }

        public T Assign()
        {
            return _valueToAssign;
        }

    }
}
