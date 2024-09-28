
using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hunter.BookStore.Authors;

public class Author : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }

    public DateTime BirthDate { get; set; }

    public string ShortBio { get; set; }

    /* This constructor is for deserialization / ORM purpose */
    private Author()
    {
    }

    public Author(Guid id, string name, DateTime birthDate, [CanBeNull] string shortBio = null)
        : base(id)
    {
        SetName(name);
        BirthDate = birthDate;
        ShortBio = shortBio;
    }

    public void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: AuthorConsts.MaxNameLength
        );
    }
}
