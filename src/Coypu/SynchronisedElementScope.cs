using Coypu.Actions;
using Coypu.Finders;
using Coypu.Queries;

namespace Coypu
{
    public class SynchronisedElementScope : ElementScope 
    {
        private readonly Options options;

        internal SynchronisedElementScope(ElementFinder elementFinder, DriverScope outerScope, Options options)
            : base(elementFinder, outerScope)
        {
            this.options = options;
        }

        public override ElementFound Now()
        {
            return timingStrategy.Synchronise(new ElementQuery(this, options));
        }

        internal override void Try(DriverAction action)
        {
            RetryUntilTimeout(action);
        }

        internal override bool Try(Query<bool> query)
        {
            return Query(query);
        }
    }
}