using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SourceTracingDto
    {
        public List<Attributions> Attributions { get; set; } = null!;
        public Data Data { get; set; } = null!;
    }

    public class Attributions
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;
    }

    public class Data
    {
        public string NormalizedText { get; set; } = null!;
        public IList<Skills> Skills { get; set; } = null!;

        public IList<Trace> Trace { get; set; } = null!;
    }

    public class Skills
    {
        public double Confidence { get; set; }
        public Skill Skill { get; set; } = null!;
    }

    public class Skill
    {
        public string Id { get; set; } = null!;
        public string InfoUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public IList<Tags> Tags { get; set; } = null!;
        public Type Type { get; set; } = null!;
    }

    public class Tags
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }

    public class Type
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class Trace
    {
        public ClassificationData ClassificationData { get; set; } = null!;
        public SurfaceForm SurfaceForm { get; set; } = null!;


    }

    public class ClassificationData
    {
        public IList<ContextForms> ContextForms { get; set; } = null!;
        public IList<Skills> Skills { get; set; } = null!;
    }

    public class SurfaceForm
    {
        public int SourceEnd { get; set; }
        public int SourceStart { get; set; }
        public string Value { get; set; } = null!;
    }

    public class ContextForms
    {
        public int SourceEnd { get; set; }
        public int SourceStart { get; set; }
        public string Value { get; set; } = null!;
    }
}
