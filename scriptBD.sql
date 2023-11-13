use Libros
GO

CREATE TABLE book (
  id int primary key IDENTITY(1,1),
  title varchar(255) NOT NULL,
  chapters int NOT NULL,
  pages int NOT NULL,
  price int NOT NULL,
  idAuthor int
  FOREIGN KEY (idAuthor) REFERENCES author(id)
);
GO


CREATE TABLE author (
  id int primary key IDENTITY(1,1),
  nameA varchar(255) NOT NULL
);
GO

USE Libros
GO

INSERT INTO [dbo].[book]
           ([title]
           ,[chapters]
           ,[pages]
           ,[price]
           ,[idAuthor])
     VALUES
           ('El regreso del oso Juancho',2, 150, 120, 1),
		   ('El oso Juancho 1',3, 200, 199, 1)



USE Libros
GO

INSERT INTO [dbo].[author]
           ([nameA])
     VALUES
           ('Saul Gomez')
GO


select * from dbo.book
select * from dbo.author