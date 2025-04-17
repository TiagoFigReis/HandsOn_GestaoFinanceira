export interface Despesa {
    id?: string;
    categoria?: string | number;
    valor: number;
    descricao: string;
    data: string;
    createdAt?: string;
    updatedAt?: string;
  }