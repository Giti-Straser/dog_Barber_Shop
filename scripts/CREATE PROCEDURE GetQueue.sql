USE [Dogs_burber_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetTodayQueue]    Script Date: 15/05/2023 00:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetQueue]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT q.queueID,c.FirstName,q.queueTime,q.registrationTime,q.customerID
	from Queues AS q
	join Customers AS c
	on  c.CustomerID = q.customerID
	where CONVERT(DATE, queueTime) >= CONVERT(DATE, GETDATE())
END
