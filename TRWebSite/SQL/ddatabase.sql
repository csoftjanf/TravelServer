USE [Travel]
GO

/****** Object: Table [dbo].[Trips] Script Date: 18/06/2020 4:02:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Trips] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [userNumber]       INT           NOT NULL,
    [userName]         NVARCHAR (50) NOT NULL,
    [travelDate]       NCHAR (10)    NOT NULL,
    [travelDistance]   FLOAT (53)    NOT NULL,
    [travelTime]       FLOAT (53)    NOT NULL,
    [GoogleTravelTime] FLOAT (53)    NOT NULL,
    [start_latitude]   FLOAT (53)    NOT NULL,
    [start_longitude]  FLOAT (53)    NOT NULL,
    [start_date]       DATETIME      NOT NULL,
    [start_address]    NVARCHAR (250) NOT NULL,
    [end_latitude]     FLOAT (53)    NOT NULL,
    [end_longitude]    FLOAT (53)    NOT NULL,
    [end_date]         DATETIME      NOT NULL,
    [end_address]     NVARCHAR (250) NOT NULL
);