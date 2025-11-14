using XcaInteropService.Commons.Commons;

namespace XcaInteropService.Commons.Models.Custom.PolicyDtos;

public class PolicyDto
{
    public string? Id { get; set; }
    public List<List<PolicyMatch>>? Rules { get; set; }
    public List<PolicyMatch>? Subjects { get; set; }
    public List<PolicyMatch>? Roles { get; set; }
    public List<PolicyMatch>? Resources { get; set; }
    public List<string>? Actions { get; set; }
    public string? Effect { get; set; }

    public void MergeWith(PolicyDto? patch, bool? append = false)
    {
        if (patch == null || patch.Rules == null) return;

        if (Rules == null)
        {
            Rules = patch.Rules;
            return;
        }

        for (int orIdx = 0; orIdx < patch.Rules.Count; orIdx++)
        {
            var patchOrGroup = patch.Rules[orIdx];

            if (orIdx >= Rules.Count)
            {
                Rules.Add(new List<PolicyMatch>(patchOrGroup));
                continue;
            }

            var targetOrGroup = Rules[orIdx];
            var dict = targetOrGroup.ToDictionary(r => r.AttributeId, r => r);

            foreach (var patchRule in patchOrGroup)
            {
                if (dict.TryGetValue(patchRule.AttributeId, out var existing))
                {
                    if (append == true)
                    {
                        var mergedValues = (existing.Value + ";" + patchRule.Value)
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Distinct()
                            .ToList();

                        dict[patchRule.AttributeId] = new PolicyMatch
                        {
                            AttributeId = existing.AttributeId,
                            Value = string.Join(";", mergedValues)
                        };
                    }
                    else
                    {
                        dict[patchRule.AttributeId] = new PolicyMatch
                        {
                            AttributeId = patchRule.AttributeId,
                            Value = patchRule.Value
                        };
                    }
                }
                else
                {
                    dict[patchRule.AttributeId] = patchRule;
                }
            }

            Rules[orIdx] = dict.Values.ToList();
        }

        foreach (var patchRule in patch?.Subjects ?? [])
        {
            var idx = Subjects.FindIndex(rule => rule.AttributeId == patchRule.AttributeId);

            if (idx < 0)
            {
                Subjects.Add(patchRule);
                continue;
            }

            Subjects[idx] = new PolicyMatch
            {
                AttributeId = patchRule.AttributeId,
                Value = patchRule.Value
            };
        }

        foreach (var patchRule in patch?.Resources ?? [])
        {
            var idx = Resources.FindIndex(rule => rule.AttributeId == patchRule.AttributeId);

            if (idx < 0)
            {
                Resources.Add(patchRule);
                continue;
            }

            Resources[idx] = new PolicyMatch
            {
                AttributeId = patchRule.AttributeId,
                Value = patchRule.Value
            };
        }

        foreach (var patchRule in patch?.Roles ?? [])
        {
            var idx = Roles.FindIndex(rule => rule.AttributeId == patchRule.AttributeId);

            if (idx < 0)
            {
                Roles.Add(patchRule);
                continue;
            }

            Roles[idx] = new PolicyMatch
            {
                AttributeId = patchRule.AttributeId,
                Value = patchRule.Value
            };
        }
    }

    public void SetDefaultValues()
    {
        if (Subjects != null)
        {
            foreach (var item in Subjects)
            {
                item.AttributeId ??= Constants.Xacml.Attribute.SubjectId;
            }
        }

        if (Roles != null)
        {
            foreach (var item in Roles)
            {
                item.AttributeId ??= Constants.Xacml.Attribute.Role;
            }
        }

        if (Resources != null)
        {
            foreach (var item in Resources)
            {
                item.AttributeId ??= Constants.Xacml.Attribute.ResourceId;
            }
        }
    }
}