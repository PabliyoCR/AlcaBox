export interface FORM {
    id: string;
    type: string;
    errorMessages?: string[];
    placeholder? : string;
    options? : FORM_OPT[]
}

export interface FORM_OPT {
    name: string;
    value? : any;
    display?: string;
}
