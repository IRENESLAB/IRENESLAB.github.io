USE [BookSubscriptions]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Text] [varchar](150) NULL,
	[PurchasePrice] [money] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[UpdatedBy] [nvarchar](450) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[EmailAddress] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[UpdatedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBook]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[BookId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[UserBook] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserBook] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserBook] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserBook] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[UserBook]  WITH CHECK ADD  CONSTRAINT [FK_UserBook] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[UserBook] CHECK CONSTRAINT [FK_UserBook]
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Delete]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	DELETE BOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Delete] @Id        INT
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Book
          SET 
              [IsDeleted] = 1
        WHERE Id = @Id;
    END;

	SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Get_All]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET ALL BOOKS
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Get_All]
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[Book]
		WHERE IsDeleted=0
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Get_By_Id]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET BOOK BY BOOK ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Get_By_Id]
@Id INT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[Book]
		WHERE Id = @Id
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Get_By_UserId]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET ALL BOOKS BY USER ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Get_By_UserId]
@UserId INT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[UserSubscription]
		WHERE UserId = @UserId
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Insert]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	INSERT INTO BOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Insert] @Name          VARCHAR(150), 
                                       @Text          VARCHAR(150), 
                                       @PurchasePrice MONEY
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Book
        ([Name], 
         [Text], 
         [PurchasePrice]
        )
        VALUES
        (@Name, 
         @Text, 
         @PurchasePrice
        );
    END;

	SELECT @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Select_All]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	SELECT ALL BOOKS - DROP DOWN
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Select_All]
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT Id, [Name], [Text]
        FROM  [BookSubscriptions].[dbo].[Book];
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Update]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	UPDATE BOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_Book_Update] @Id            INT, 
                                       @Name          VARCHAR(150), 
                                       @Text          VARCHAR(150), 
                                       @PurchasePrice MONEY
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Book
          SET 
              [Name] = @Name, 
              [Text] = @Text, 
              [PurchasePrice] = @PurchasePrice, 
              [UpdatedDate] = GETDATE()
        WHERE Id = @Id;
    END;

	SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Delete]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	DELETE USER
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Delete] @Id        INT
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE [User]
          SET 
              [IsDeleted] = 1
        WHERE Id = @Id;
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Get_All]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET ALL USERS
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Get_All]
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM [BookSubscriptions].[dbo].[User]
		WHERE IsDeleted = 0
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Get_By_Id]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET USER BY USER ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Get_By_Id]
@Id BIGINT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[User]
		WHERE Id = @Id
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Insert]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	INSERT INTO USER
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Insert] @FirstName    VARCHAR(150), 
                                       @LastName     VARCHAR(150), 
                                       @EmailAddress VARCHAR(150)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO [User]
        ([FirstName], 
         [LastName], 
         [EmailAddress]
        )
        VALUES
        (@FirstName, 
         @LastName, 
         @EmailAddress
        );
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Select_All]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	SELECT ALL USERS - DROP DOWN
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Select_All]
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT Id, FirstName + ' ' + LastName
        FROM [BookSubscriptions].[dbo].[User];
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Update]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	UPDATE USER
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Update] @Id           INT, 
                                       @FirstName    VARCHAR(150), 
                                       @LastName     VARCHAR(150), 
                                       @EmailAddress VARCHAR(150)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE [User]
          SET 
              [FirstName] = @FirstName, 
              [LastName] = @LastName, 
              [EmailAddress] = @EmailAddress
        WHERE Id = @Id;
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Delete]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	DELETE USERBOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Delete] @Id        INT
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE [UserBook]
          SET 
              [IsDeleted] = 1
        WHERE Id = @Id;
    END;

	SELECT @Id
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Get]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET BOOK SUBSCRIPTION BY IDs
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Get]
@UserId BIGINT,
@BookId INT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[UserBook]
		WHERE BookId = @BookId
		AND UserId = @UserId
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Get_All]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET ALL BOOK SUBSCRIPTIONS
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Get_All]
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT B.Id [BookId]
		,B.[Name]
		,B.[Text]
		,b.[PurchasePrice]
		,UB.[Id] 
		,UB.[UserId]
		,ISNULL(UB.[IsActive],0) IsActive
        FROM [dbo].[Book] B WITH(NOLOCK) 
		LEFT JOIN [BookSubscriptions].[dbo].[UserBook] UB WITH(NOLOCK) ON UB.BookId = B.Id 
		WHERE B.IsActive = 1 AND B.IsDeleted=0
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Get_By_BookId]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET BOOK SUBSCRIPTION BY BOOK ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Get_By_BookId]
@Id INT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[UserBook]
		WHERE BookId = @Id
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Get_By_Id]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET BOOK SUBSCRIPTION BY ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Get_By_Id]
@Id BIGINT
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT *
        FROM  [BookSubscriptions].[dbo].[UserBook]
		WHERE Id = @Id
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Get_By_UserId]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	GET BOOK SUBSCRIPTION BY USER ID ([UserAccess].[dbo].[AspNetUsers])
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Get_By_UserId]
@UserId NVARCHAR(450)='7d3cd161-fdb4-4cb0-ad72-fb7cda4b908e'
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT B.Id [BookId]
		,B.[Name]
		,B.[Text]
		,b.[PurchasePrice]
		,UB.[Id] 
		,@UserId[UserId]
		,ISNULL(UB.[IsActive],0) IsActive
        FROM [dbo].[Book] B WITH(NOLOCK) 
		LEFT JOIN [BookSubscriptions].[dbo].[UserBook] UB WITH(NOLOCK) ON UB.BookId = B.Id
		AND (UserId = @UserId OR @UserId='')
		WHERE B.IsActive = 1 AND B.IsDeleted=0
    END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Insert]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	INSERT INTO USERBOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Insert] @UserId NVARCHAR(450), 
                                           @BookId INT, 
                                           @IsActive BIT
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @Id INT;
        SET @Id =
        (
            SELECT Id
            FROM [UserBook]
            WHERE [UserId] = @UserId
                  AND [BookId] = @BookId
        );
        IF @Id > 0
            BEGIN
                UPDATE [UserBook]
                  SET 
                      [IsActive] = @IsActive
                WHERE Id = @Id;
				SELECT @Id
        END;
            ELSE
            BEGIN
                INSERT INTO [UserBook]
                ([UserId], 
                 [BookId]
                )
                VALUES
                (@UserId, 
                 @BookId
                ); 
				
				 SELECT @@IDENTITY;
        END;
    END;
      
GO
/****** Object:  StoredProcedure [dbo].[sp_UserBook_Update]    Script Date: 26/10/2020 12:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		IRENE MARITZ
-- Create date: 19 OCTOBER 2020
-- Description:	UPDATE USERBOOK
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserBook_Update] @Id       INT, 
                                           @IsActive BIT
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE [UserBook]
          SET 
              [IsActive] = @IsActive
        WHERE Id = @Id;
    END;

	SELECT @Id
GO
