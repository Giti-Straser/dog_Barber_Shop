USE [Dogs_burber_shop]
GO
/****** Object:  StoredProcedure [dbo].[GetTodayQueue]    Script Date: 10/05/2023 15:10:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetTodayQueue]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT q.queueID,c.FirstName,q.queueTime,q.registrationTime,q.customerID
	from Queues AS q
	join Customers AS c
	on  c.CustomerID = q.customerID
	where CONVERT(DATE, queueTime) = CONVERT(DATE, GETDATE())
END
