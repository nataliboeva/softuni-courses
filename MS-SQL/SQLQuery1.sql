CREATE DATABASE EuroLeagues
GO
USE EuroLeagues;
GO

CREATE TABLE Leagues (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Teams (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50) NOT NULL UNIQUE,
			 [City] NVARCHAR(50) NOT NULL,
			 [LeagueId] INT NOT NULL,
			 FOREIGN KEY (LeagueId) REFERENCES Leagues(Id)
);

CREATE TABLE Players (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(100) NOT NULL,
			 [Position] NVARCHAR(20) NOT NULL
);

CREATE TABLE Matches (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [HomeTeamId] INT NOT NULL,
			 [AwayTeamId] INT NOT NULL,
			 [MatchDate] DATETIME2 NOT NULL,
			 [HomeTeamGoals] INT NOT NULL DEFAULT 0,
			 [AwayTeamGoals] INT NOT NULL DEFAULT 0,
			 [LeagueId] INT NOT NULL,
			 FOREIGN KEY (HomeTeamId) REFERENCES Teams(Id),
			 FOREIGN KEY (AwayTeamId) REFERENCES Teams(Id),
			 FOREIGN KEY (LeagueId) REFERENCES Leagues(Id)
);

CREATE TABLE PlayersTeams (
			 [PlayerId] INT NOT NULL,
			 [TeamId] INT NOT NULL,
			 PRIMARY KEY (PlayerId, TeamId),
			 FOREIGN KEY (PlayerId) REFERENCES Players(Id),
			 FOREIGN KEY (TeamId) REFERENCES Teams(Id)
);

CREATE TABLE PlayerStats (
			 [PlayerId] INT PRIMARY KEY,
			 [Goals] INT NOT NULL DEFAULT 0,
			 [Assists] INT NOT NULL DEFAULT 0,
			 FOREIGN KEY (PlayerId) REFERENCES Players(Id)
);

CREATE TABLE TeamStats (
			 [TeamId] INT PRIMARY KEY,
			 [Wins] INT NOT NULL DEFAULT 0,
			 [Draws] INT NOT NULL DEFAULT 0,
			 [Losses] INT NOT NULL DEFAULT 0,
			 FOREIGN KEY (TeamId) REFERENCES Teams(Id)
);

INSERT INTO Leagues ([Name]) VALUES ('Eredivisie');

INSERT INTO Teams ([Name], [City], [LeagueId]) VALUES
('PSV', 'Eindhoven', 6),
('Ajax', 'Amsterdam', 6);

INSERT INTO Players ([Name], [Position]) VALUES
('Luuk de Jong', 'Forward'),
('Josip Sutalo', 'Defender');

INSERT INTO Matches ([HomeTeamId], [AwayTeamId], [MatchDate], [HomeTeamGoals], [AwayTeamGoals], [LeagueId]) VALUES
(98, 97, '2024-11-02 20:45:00', 3, 2, 6);

INSERT INTO PlayersTeams ([PlayerId], [TeamId]) VALUES
(2305, 97),
(2306, 98);

INSERT INTO PlayerStats ([PlayerId], [Goals], [Assists]) VALUES
(2305, 2, 0),
(2306, 2, 0);

INSERT INTO TeamStats ([TeamId], [Wins], [Draws], [Losses]) VALUES
(97, 15, 1, 3),
(98, 14, 3, 2);

UPDATE PlayerStats
SET Goals = Goals + 1
WHERE PlayerId IN (
    SELECT pt.PlayerId
    FROM PlayersTeams pt
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    JOIN Players p ON pt.PlayerId = p.Id
    WHERE p.Position = 'Forward' AND l.Name = 'La Liga'
);

DELETE FROM PlayerStats WHERE PlayerId IN (
    SELECT p.Id FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie'
);

DELETE FROM PlayersTeams WHERE PlayerId IN (
    SELECT p.Id FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie'
);

DELETE FROM Players WHERE Id IN (
    SELECT p.Id FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie'
);

