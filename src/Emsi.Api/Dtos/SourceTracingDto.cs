using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SourceTracingDto
    {
        public List<AttributionDto> Attributions { get; set; } = null!;
        public Data Data { get; set; } = null!;
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
        public SkillDto Skill { get; set; } = null!;
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
