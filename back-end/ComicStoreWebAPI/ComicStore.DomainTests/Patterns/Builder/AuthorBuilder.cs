using ComicStore.Domain.POCO;
using System;

namespace ComicStore.DomainTests.Patterns.Builder
{
    public class AuthorBuilder
           : TestBuilder<AuthorBuilder, Author>
    {
        public AuthorBuilder WithBirthDate(DateTime birthDate)
        {
            Subject.BirthDate = birthDate;
            return this;
        }
    }
}