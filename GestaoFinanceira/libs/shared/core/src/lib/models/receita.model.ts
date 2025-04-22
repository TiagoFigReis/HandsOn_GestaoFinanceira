export interface Receita {
    id?: string;
    valor: number;
    descricao: string;
    data: string;
    fonte?: string | number;
    comprovante?: File | string;
    createdAt?: string;
    updatedAt?: string;
  }
  