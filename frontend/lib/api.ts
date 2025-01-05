"use server";

import type { AxiosRequestConfig } from "axios";
import axios from "axios";

export const BASE_URL = process.env.NEXT_PUBLIC_API_URL;

export const fetch = async <T,>(path: string, options: AxiosRequestConfig<any> = {}) => {
    return await axios<T>(`${BASE_URL}${path}`, {
        ...options,
    });
};