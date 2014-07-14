﻿using BankTransferSample.Commands;
using BankTransferSample.Domain;
using ECommon.Components;
using ECommon.Utilities;
using ENode.Commanding;

namespace BankTransferSample.CommandHandlers
{
    /// <summary>银行转账交易相关命令处理
    /// </summary>
    [Component]
    public class TransferTransactionCommandHandlers :
        ICommandHandler<StartTransferTransactionCommand>,                       //开始转账交易
        ICommandHandler<ConfirmTransferOutPreparationCommand>,                  //确认预转出
        ICommandHandler<ConfirmTransferInPreparationCommand>,                   //确认预转入
        ICommandHandler<ConfirmTransferOutCommand>,                             //确认转出
        ICommandHandler<ConfirmTransferInCommand>,                              //确认转入
        ICommandHandler<CancelTransferTransactionCommand>                       //取消交易
    {
        public void Handle(ICommandContext context, StartTransferTransactionCommand command)
        {
            context.Add(new TransferTransaction(ObjectId.GenerateNewStringId(), command.TransactionInfo));
        }
        public void Handle(ICommandContext context, ConfirmTransferOutPreparationCommand command)
        {
            context.Get<TransferTransaction>(command.AggregateRootId).ConfirmTransferOutPreparation();
        }
        public void Handle(ICommandContext context, ConfirmTransferInPreparationCommand command)
        {
            context.Get<TransferTransaction>(command.AggregateRootId).ConfirmTransferInPreparation();
        }
        public void Handle(ICommandContext context, ConfirmTransferOutCommand command)
        {
            context.Get<TransferTransaction>(command.AggregateRootId).ConfirmTransferOut();
        }
        public void Handle(ICommandContext context, ConfirmTransferInCommand command)
        {
            context.Get<TransferTransaction>(command.AggregateRootId).ConfirmTransferIn();
        }
        public void Handle(ICommandContext context, CancelTransferTransactionCommand command)
        {
            context.Get<TransferTransaction>(command.AggregateRootId).Cancel();
        }
    }
}
