using Bank_Management_System.AppDbContext;
using Bank_Management_System.Dtos;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services.CustomerRepository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly dbcontext _context;

        public CustomerRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAll(AllCustomerDto dto)
        {
            var result = new Customer
            {
                CustomerEmailAddress = dto.CustomerEmailAddress,
                CustomerName = dto.CustomerName,
                CustomerPhone = dto.CustomerPhone,
                BankCard = new BankCard
                {
                    BankCardName = dto.BankCardDto.BankCardName,
                    ExpiryDate = dto.BankCardDto.ExpiryDate,
                },
                Account = dto.AccountDto.Select(x=> new Account
                {
                    AccountNumber = x.AccountNumber,
                    Balance = x.Balance,
                    Transaction = x.TransactionDto.Select(t => new Transaction
                    {

                        DateTime = DateTime.UtcNow,
                        Amount = t.Amount,
                    }).ToList()
                }).ToList(),
            };
            _context.Customerss.Add(result);
            _context.SaveChanges();
        }

        public List<AllCustomerDto> GetAll()
        {
            var result = _context.Customerss.
                Include(x => x.BankCard).
                Include(x => x.Account).
                ThenInclude(x => x.Transaction).
                Select(i => new AllCustomerDto
                {
                    CustomerName = i.CustomerName,
                    CustomerPhone = i.CustomerPhone,
                    CustomerEmailAddress = i.CustomerEmailAddress,  

                    AccountDto = i.Account.Select(t => new AccountDto
                    {
                        AccountNumber= t.AccountNumber,
                        Balance = t.Balance,
                        TransactionDto = t.Transaction.Select(b => new TransactionDto
                        {
                            Amount= b.Amount,
                            DateTime = b.DateTime,
                        }).ToList(),
                    }).ToList(),
                    BankCardDto = new BankCardDto
                    {
                        BankCardName = i.BankCard.BankCardName,
                        ExpiryDate = i.BankCard.ExpiryDate,
                    }
                }).ToList();
            return result;
        }

        public AllCustomerDto GetById(int id)
        {
            var result = _context.Customerss.
                Include(x=>x.BankCard).
                Include(x=>x.Account).
                ThenInclude(x=>x.Transaction).
                FirstOrDefault(x=>x.CustomerId == id);

            return new AllCustomerDto
            {
                CustomerEmailAddress = result.CustomerEmailAddress,
                CustomerName = result.CustomerName,
                CustomerPhone = result.CustomerPhone,
                AccountDto = result.Account.Select(t => new AccountDto
                {
                    AccountNumber = t.AccountNumber,
                    Balance = t.Balance,
                    TransactionDto = t.Transaction.Select(i => new TransactionDto
                    {
                        Amount = i.Amount,
                        DateTime = i.DateTime,
                    }).ToList(),
                }).ToList(),
                BankCardDto = new BankCardDto
                {
                    BankCardName= result.BankCard.BankCardName,
                    ExpiryDate = result.BankCard.ExpiryDate,
                }
            };
        }
    }
}
