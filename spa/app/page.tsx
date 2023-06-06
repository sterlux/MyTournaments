"use client";
import { useEffect, useState } from "react";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { Delete } from "@mui/icons-material";
import Alert from "@mui/material/Alert";

type Player = {
  id: string | number;
  firstName: string;
  lastName: string;
  // other player properties go here
};

export default function Home() {
  const [players, setPlayers] = useState<Player[]>([]);
  const [successMessage, setSuccessMessage] = useState("");

  useEffect(() => {
    fetch("http://localhost:8000/api/v1/Players")
      .then((res) => res.json())
      .then((data) => {
        setPlayers(data);
      });
  }, []);

  const onDeleteClick = (id: any) => {
    fetch(`http://localhost:8000/api/v1/Players/${id}`, {
      method: "DELETE",
    })
      .then((res) => res.json())
      .then((data) => {
        setSuccessMessage(data);
        setPlayers(players.filter((player) => player.id !== id));
      });
  };

  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 70 },
    { field: "firstName", headerName: "First name", width: 130 },
    { field: "lastName", headerName: "Last name", width: 130 },
    {
      field: "edit",
      headerName: "Edit",
      width: 130,
      renderCell: (params) => <a href={`/players/${params.id}`}>Edit</a>,
    },
    {
      field: "delete",
      headerName: "Delete",
      width: 130,
      renderCell: (params) => {
        return (
          <div onClick={() => onDeleteClick(params.id)}>
            <Delete />
          </div>
        );
      },
    },
  ];

  return (
    <div>
      <h1>Jugadores</h1>
      <h2>Lista de jugadores</h2>

      {successMessage && <Alert severity='success'>{successMessage}</Alert>}

      <DataGrid
        rows={players}
        columns={columns}
        initialState={{
          pagination: {
            paginationModel: { page: 0, pageSize: 5 },
          },
        }}
        pageSizeOptions={[5, 10]}
        // checkboxSelection
      />
    </div>
  );
}
