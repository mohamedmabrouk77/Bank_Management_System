using Bank_Management_System.AppDbContext;
using Bank_Management_System.Dtos;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services.AccountRepository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly dbcontext _context;

        public AccountRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAll(AllAccountDto dto)
        {
            var result = new Account
            {
                AccountNumber = dto.AccountNumber,
                Balance = dto.Balance,
                Transaction = dto.TransactionDto.Select(i => new Transaction
                {
                    DateTime = DateTime.UtcNow,
                    Amount = i.Amount,
                }).ToList(),
                Customer = new Customer
                {
                    CustomerEmailAddress = dto.CustomerDto.CustomerEmailAddress,
                    CustomerName = dto.CustomerDto.CustomerName,
                    CustomerPhone = dto.CustomerDto.CustomerPhone,
                    BankCard = new BankCard
                    {
                        BankCardName = dto.CustomerDto.BankCardDto.BankCardName,
                        ExpiryDate = DateTime.UtcNow,
                    },
                    
                }
            };
            _context.Accountss.Add(result);
            _context.SaveChanges();
        }

        public void DeleteAllAccount(int id)
        {
            var result = _context.Accountss.
                Include(x => x.Transaction).
                Include(x => x.Customer).
                ThenInclude(x => x.BankCard).
                FirstOrDefault(x => x.AccountId == id);
            if(result != null)
            {
                _context.Accountss.Remove(result);
                _context.Customerss.Remove(result.Customer);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<AllAccountDto> GetAll()
        {
            var result = _context.Accountss.
                Include(x => x.Transaction).
                Include(x => x.Customer).
                ThenInclude(x => x.BankCard).
                Select(x => new AllAccountDto
                {
                    AccountNumber = x.AccountNumber,
                    Balance = x.Balance,
                    CustomerDto = new CustomerDto
                    {
                        CustomerEmailAddress = x.Customer.CustomerEmailAddress,
                        CustomerName = x.Customer.CustomerName,
                        CustomerPhone = x.Customer.CustomerPhone,
                        BankCardDto = new BankCardDto
                        {
                            BankCardName = x.Customer.BankCard.BankCardName,
                            ExpiryDate = x.Customer.BankCard.ExpiryDate,
                        }
                    },
                    TransactionDto = x.Transaction.Select(i => new TransactionDto
                    {
                        Amount = i.Amount,
                        DateTime = DateTime.UtcNow,
                    }).ToList(),
                }).ToList();
            return result;
        }


        public void UpdateAllAccount(AllAccountDto dto, int id)
        {
            var result = _context.Accountss.
                Include(x => x.Transaction).
                Include(x => x.Customer).
                ThenInclude(x => x.BankCard).
                FirstOrDefault(x => x.AccountId == id);

            if(result != null)
            {
                result.AccountNumber = dto.AccountNumber;
                result.Balance = dto.Balance;
                result.Transaction = dto.TransactionDto.Select(i => new Transaction
                {
                    Amount = i.Amount,
                    DateTime = DateTime.UtcNow,
                }).ToList();
                result.Customer = new Customer
                {
                    CustomerName = dto.CustomerDto.CustomerName,
                    CustomerEmailAddress = dto.CustomerDto.CustomerEmailAddress,
                    CustomerPhone = dto.CustomerDto.CustomerPhone,
                    BankCard = new BankCard
                    {
                        BankCardName = dto.CustomerDto.BankCardDto.BankCardName,
                        ExpiryDate = DateTime.UtcNow
                    }
                };
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Accountss.Update(result);
            _context.SaveChanges();
        }
    }
}
