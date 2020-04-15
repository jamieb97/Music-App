use master 

go

drop database if exists MusicDB

go

create database MusicDB

go

use MusicDB

go

CREATE TABLE Track (
    TrackID int not null primary key identity,
    TrackName varchar (100) null,
    Artist varchar (100) null,
    ReleaseDate int null,
    Explicits bit null,
    TrackLength time null,
    TrackLink varchar (255) null
);

INSERT INTO Track (TrackName, Artist, ReleaseDate, Explicits, TrackLength) VALUES
('The Morning', 'The Weeknd', 2012, 1, '5:15');
GO