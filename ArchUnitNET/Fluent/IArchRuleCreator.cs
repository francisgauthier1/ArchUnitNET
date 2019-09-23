﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Syntax;

namespace ArchUnitNET.Fluent
{
    public interface IArchRuleCreator<TRuleType> : ICanBeEvaluated where TRuleType : ICanBeAnalyzed
    {
        void AddObjectFilter(ObjectFilter<TRuleType> objectFilter);
        void AddObjectFilterConjunction(LogicalConjunction logicalConjunction);
        void AddCondition(ICondition<TRuleType> condition);
        void AddConditionConjunction(LogicalConjunction logicalConjunction);
        void AddConditionReason(string reason);
        void AddFilterReason(string reason);

        void BeginComplexCondition<TReferenceType>(RelationCondition<TRuleType, TReferenceType> relationCondition)
            where TReferenceType : ICanBeAnalyzed;

        void ContinueComplexCondition<TReferenceType>(ObjectProvider<TReferenceType> referenceObjectProvider,
            ObjectFilter<TReferenceType> objectFilter) where TReferenceType : ICanBeAnalyzed;
    }
}