import axios, { AxiosResponse } from "axios"
import routeProvider from "./RouteProvider"
import InvalidInputError from "../errors/InvalidInputError"
import CalculatorResult from "../models/CalculatorResult"

export default class CalculatorService {
    add = async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getAddRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    sub = async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getSubRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    mul = async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getMulRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    div = async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getDivRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    pow = async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getPowRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    root= async (a: string, b: string) => {
        this.throwIfMultipleEmpty(a, b)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getRootRoute(), {
                params: {
                    a: a,
                    b: b
                }
            }))
    }

    expr = async (expression: string) => {
        this.throwIfEmpty(expression)
        return this.handler(() =>
            axios.get<CalculatorResult>(routeProvider.getExprRoute(), {
                params: {
                    expression: expression
                }
            }))
    }

    private handler = async (action: () => Promise<AxiosResponse<CalculatorResult>>) => {
        try {
            var response = await action()

            return response.data
        }
        catch (error) {
            if (axios.isAxiosError(error) && error.response!.status === 400)
                throw new InvalidInputError(error.response?.data.errorMessage)
            
            throw error
        }
    }

    private throwIfEmpty = (a: string) => {
        if (a === "")
            throw new InvalidInputError("Empty field")
    }

    private throwIfMultipleEmpty = (a: string, b: string) => {
        if (a === "" || b === "")
            throw new InvalidInputError("Empty field")
    }
}