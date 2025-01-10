import type {
  GetServerSidePropsContext,
} from "next";
import { getCsrfToken } from "next-auth/react";


export async function getServerSideProps(context: GetServerSidePropsContext) {
    return {
      props: {
        csrfToken: await getCsrfToken(),
      },
    }
  }