﻿namespace RecruitmentTask.Dto
{
    /// <summary>Invoice data transfer object</summary>
    public class InvoiceDto
    {
        /// <summary>Id</summary>
        public int Id { get; set; }

        /// <summary>Invoice number</summary>
        public string Number { get; set; }

        /// <summary>Invoice name</summary>
        public string Name { get; set; }

        /// <summary>Invoice created date</summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>Payment date</summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>Account number</summary>
        public string AccountNumber { get; set; }

        /// <summary>List of invoice items</summary>
        public IEnumerable<ItemDto> Items { get; set; }

        /// <summary>Total amount</summary>
        public decimal TotalAmount { get; set; }

        /// <summary>Constructor</summary>
        public InvoiceDto()
        {
            Items = new List<ItemDto>();
        }
    }
}
