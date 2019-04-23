using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Accounting {
    public class AccountManager : AggregateManager<Account, AccountId, Command<Account, AccountId>> { }
}