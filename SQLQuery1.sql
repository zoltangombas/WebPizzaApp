SELECT C.Id, C.Irsz, C.Kozterulet, C.Hazszam, C.Csengo, C.MegrendeloId, M.Id AS MiD, M.Nev FROM Cimek AS C 
JOIN Megrendelok AS M 
ON C.MegrendeloId = M.Id


SELECT * FROM Cimek AS C 
JOIN Megrendelok AS M 
ON C.MegrendeloId = M.Id
